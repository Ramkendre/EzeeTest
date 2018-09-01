using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ReportDAL
/// </summary>
public class ReportDAL
{
    public ReportDAL()
    {
    }

    public static double getVoucherBalance(string Sql)
    {
        double Amount = 0;
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Sql;
            SqlDataReader  dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Amount = Convert.ToDouble(dr.GetValue(0));
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            dr.Close();
            cmd.Dispose();
        }
        return Amount;
    }

    public static string getVoucherBalanceType(string Sql)
    {
        string Type = "";
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Sql;
            SqlDataReader  dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Type = Convert.ToString(dr.GetValue(0));
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            dr.Close();
            cmd.Dispose();
        }
        return Type;
    }

    public static double getBalanceByGroup(int GroupId,string CompanyId)
    {
        double Amount = 0;
        DataSet ds = new DataSet();
        //string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select LedgerId from tblAccLedger Where GroupId=" + GroupId+" and CompanyId="+CompanyId+"";
            SqlDataReader  dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    int LedgerId = Convert.ToInt32(dr.GetValue(0));
                    try
                    {
                        Report rpt = new Report();
                        string amt = rpt.getLedgerOpBalance(LedgerId, System.DateTime.Now);
                        amt = amt.Substring(0, amt.Length - 2);
                        Amount = Amount + Convert.ToDouble(amt);
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            dr.Close();
            cmd.Dispose();
        }
        return Amount;
    }

    public static List<Report> GetReportData(string Sql)
    {


        List<Report> repList = new List<Report>();
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Sql;
            SqlDataReader  dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Report rpt = new Report();
                rpt.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);
                DateTime dt = Convert.ToDateTime(dr["VoucherDate"]);
                rpt.VoucherDate = Convert.ToDateTime(dr["VoucherDate"]);
                rpt.LedgerName = Convert.ToString(dr["LedgerName"]);
                rpt.VoucherType = Convert.ToString(dr["VoucherType"]);
                rpt.Debit = Convert.ToDouble(dr["Debit"]);
                rpt.Credit = Convert.ToDouble(dr["Credit"]);
                repList.Add(rpt);
            }
        }
        return repList;


    }

    public static List<TrailReport> GetTrailBalanceReport(DateTime fdt, DateTime tdt,string CompanyId)
    {


        List<TrailReport> repList = new List<TrailReport>();
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select LedgerId, LedgerName,OpeningBalance,CrDr from tblAccLedger where CompanyId="+CompanyId+" order by LedgerName";
            SqlDataReader  dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                try
                {
                    string LedgerId = Convert.ToString(dr["LedgerId"]);
                    string LedgerName = Convert.ToString(dr["LedgerName"]);

                    Report rpt = new Report();
                    TrailReport trpt = new TrailReport();
                    trpt.LedgerId = Convert.ToInt32(LedgerId);
                    trpt.LedgerName = Convert.ToString(LedgerName);
                    //For Calculation of Opening Balance
                    try
                    {
                        string OpBalance = rpt.getLedgerOpBalance(Convert.ToInt32(LedgerId), fdt);
                        string Type = OpBalance.Substring(OpBalance.Length - 2);
                        OpBalance = OpBalance.Substring(0, OpBalance.Length - 2);
                        if (Type == "Dr")
                        {
                            trpt.OpDebit = OpBalance;
                        }
                        else if (Type == "Cr")
                        {
                            trpt.OpCredit = OpBalance;
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    //Get the current working Balance
                    try
                    {
                        string Sql = "Select Sum(Debit)-Sum(Credit) as Amount from tblAccVoucherDetail where " +
                            " VoucherId in (select VoucherId from tblAccVoucherMain where VoucherDate>='" + fdt.ToShortDateString() + "' " +
                            " And VoucherDate<='" + tdt.ToShortDateString() + "' )and LedgerId=" + LedgerId + " ";
                        double curbalance = getVoucherBalance(Sql);
                        if (curbalance >= 0)
                        {
                            trpt.Debit = curbalance.ToString();

                        }
                        else
                        {
                            curbalance = -1 * curbalance;
                            trpt.Credit = curbalance.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    //Finding closing Balance
                    try
                    {
                        string ClBalance = rpt.getVoucherBalance(Convert.ToInt32(LedgerId));
                        string ClType = ClBalance.Substring(ClBalance.Length - 2);
                        ClBalance = ClBalance.Substring(0, ClBalance.Length - 2);
                        if (ClType == "Dr")
                        {
                            trpt.ClDebit = ClBalance;
                        }
                        else if (ClType == "Cr")
                        {
                            trpt.ClCredit = ClBalance;
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    repList.Add(trpt);
                }
                catch (Exception ex)
                {
                }
            }
        }
        return repList;


    }

    public static List<PLReport> GetPLExpenseReport(string CompanyId)
    {


        List<PLReport> ExpenseList = new List<PLReport>();
        PLReport plGroup;
        DataSet ds = new DataSet();
        //string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            double SaleAmount = getBalanceByGroup(19,CompanyId );
            double PurchaseAmount = getBalanceByGroup(18,CompanyId );


            plGroup = new PLReport();
            plGroup.Particulars = "Purchase Account";
            plGroup.LedAmount = "0";
            plGroup.GroupAmount = PurchaseAmount.ToString();
            ExpenseList.Add(plGroup);
            //For Ledger Amount

            using (SqlConnection con2 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {
                con2.Open();
                SqlCommand  cmd2 = con2.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "Select LedgerId,LedgerName from tblAccLedger Where GroupId=18 and CompanyId="+CompanyId +"";
                SqlDataReader  dr2 = cmd2.ExecuteReader();
                try
                {
                    while (dr2.Read())
                    {
                        int LedgerId = Convert.ToInt32(dr2.GetValue(0));
                        string LedgerName = Convert.ToString(dr2.GetValue(1));
                        try
                        {
                            Report rpt = new Report();
                            string amt = rpt.getLedgerOpBalance(LedgerId, System.DateTime.Now);
                            //Amount = Amount + amt;
                            string Type = amt.Substring(amt.Length - 2);
                            amt = amt.Substring(0, amt.Length - 2);
                            double Amount = Convert.ToDouble(amt);
                            if (Type == "Cr")
                            {
                                Amount = -1 * Amount;
                            }
                            PLReport plLed = new PLReport();
                            plLed.Particulars = LedgerName;
                            plLed.LedAmount = Amount.ToString();
                            plLed.GroupAmount = "0";
                            ExpenseList.Add(plLed);
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
                dr2.Close();
                cmd2.Dispose();
            }

            if (PurchaseAmount < SaleAmount)
            {

                plGroup = new PLReport();
                plGroup.Particulars = "";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = "0";
                ExpenseList.Add(plGroup);

                plGroup = new PLReport();
                plGroup.Particulars = "Gross Profit";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = Convert.ToString(SaleAmount - PurchaseAmount);
                ExpenseList.Add(plGroup);

                plGroup = new PLReport();
                plGroup.Particulars = "";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = "0";
                ExpenseList.Add(plGroup);
            }
            else
            {
                plGroup = new PLReport();
                plGroup.Particulars = "";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = "0";
                ExpenseList.Add(plGroup);

                plGroup = new PLReport();
                plGroup.Particulars = "";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = "0";
                ExpenseList.Add(plGroup);

                plGroup = new PLReport();
                plGroup.Particulars = "";
                plGroup.LedAmount = "0";
                plGroup.GroupAmount = "0";
                ExpenseList.Add(plGroup);

            }

            //double PurchaseAmount = 0;
            con.Open();
            SqlCommand  cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select GroupName,groupId from tblAccGroup where Nature='E' and GroupId<>18 order by GroupId desc";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                try
                {
                    int GroupId = Convert.ToInt32(dr["GroupId"]);
                    string GroupName = Convert.ToString(dr["GroupName"]);

                    double GroupAmount = getBalanceByGroup(GroupId,CompanyId );
                    if (GroupAmount > 0 || GroupId == 18)
                    {
                        plGroup = new PLReport();
                        plGroup.Particulars = GroupName;
                        plGroup.LedAmount = "0";
                        plGroup.GroupAmount = GroupAmount.ToString();
                        ExpenseList.Add(plGroup);
                        //For Ledger Amount

                        using (SqlConnection con1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
                        {
                            con1.Open();
                            SqlCommand  cmd1 = con1.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "Select LedgerId,LedgerName from tblAccLedger Where GroupId=" + GroupId+" AND CompanyId="+CompanyId +"" ;
                            SqlDataReader  dr1 = cmd1.ExecuteReader();
                            try
                            {
                                while (dr1.Read())
                                {
                                    int LedgerId = Convert.ToInt32(dr1.GetValue(0));
                                    string LedgerName = Convert.ToString(dr1.GetValue(1));
                                    try
                                    {
                                        Report rpt = new Report();
                                        string amt = rpt.getLedgerOpBalance(LedgerId, System.DateTime.Now);
                                        //Amount = Amount + amt;
                                        string Type = amt.Substring(amt.Length - 2);
                                        amt = amt.Substring(0, amt.Length - 2);
                                        double Amount = Convert.ToDouble(amt);
                                        if (Type == "Cr")
                                        {
                                            Amount = -1 * Amount;
                                        }
                                        PLReport plLed = new PLReport();
                                        plLed.Particulars = LedgerName;
                                        plLed.LedAmount = Amount.ToString();
                                        plLed.GroupAmount = "0";
                                        ExpenseList.Add(plLed);
                                    }
                                    catch (Exception ex)
                                    { }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                            }
                            dr1.Close();
                            cmd1.Dispose();
                        }



                        //End For Ledger Amount

                    }


                }
                catch (Exception ex)
                {
                }
            }
        }
        plGroup = new PLReport();
        plGroup.Particulars = "";
        plGroup.LedAmount = "0";
        plGroup.GroupAmount = "0";
        ExpenseList.Add(plGroup);

        plGroup = new PLReport();
        plGroup.Particulars = "";
        plGroup.LedAmount = "0";
        plGroup.GroupAmount = "0";
        ExpenseList.Add(plGroup);

        plGroup = new PLReport();
        plGroup.Particulars = "";
        plGroup.LedAmount = "0";
        plGroup.GroupAmount = "0";
        ExpenseList.Add(plGroup);

        return ExpenseList;


    }

    

}