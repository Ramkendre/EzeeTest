using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Report
/// </summary>
public class Report
{
	private List<Report> _getAllReportData;
        private int _VoucherNo;
        private DateTime _VoucherDate;

        private string _LedgerName;
        private string _VoucherType;

       

        private double _Debit;
        private double _Credit;

       
        public Report()
        {
        }
        public int VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
        }
        public DateTime VoucherDate
        {
            get { return _VoucherDate; }
            set { _VoucherDate = value; }
        }
        public string LedgerName
        {
            get { return _LedgerName; }
            set { _LedgerName = value; }
        }
        public string VoucherType
        {
            get { return _VoucherType; }
            set { _VoucherType = value; }
        }
       
        public double Debit
        {
            get { return _Debit; }
            set { _Debit = value; }
        }
        public double Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
       

       
        public List<Report> GetReportCollection
        {
            get { return _getAllReportData; }
            set { _getAllReportData = value; }
        }
        public string getVoucherBalance(int LedgerId)
        {
            string CurrentBalance = "";
            string Sql = "Select sum(Debit)-sum(Credit) as Balance from tblAccVoucherDetail where LedgerId=" + LedgerId.ToString()+"";
            double CurrBalance = ReportDAL.getVoucherBalance(Sql);
            Sql = "Select OpeningBalance from tblAccLedger where LedgerId=" + LedgerId.ToString() + "";
            double OpeningBalance = ReportDAL.getVoucherBalance(Sql);
            Sql = "Select CrDr from tblAccLedger where LedgerId=" + LedgerId.ToString() + "";
            string OpeningType = ReportDAL.getVoucherBalanceType(Sql);
            double Balance = 0;
            string TotalBalance = "";
            if (OpeningType == "Dr")
            {
                Balance = OpeningBalance + CurrBalance;
            }
            else if (OpeningType == "Cr")
            {
                Balance = -OpeningBalance + CurrBalance;
            }
            else
            {
                Balance = CurrBalance;
            }
            if (Balance >= 0)
            {
                TotalBalance = Balance.ToString() + "Dr";
            }
            else
            {
                Balance = -1 * Balance;
                TotalBalance = Balance.ToString() + "Cr";
            }
            return TotalBalance;

        }

        //Returns LedgerClosing balance at the specified date
        public string getLedgerOpBalance(int LedgerId,DateTime dt)
        {
            string CurrentBalance = "";
            string Sql = "Select sum(Debit)-sum(Credit) as Balance from tblAccVoucherDetail where LedgerId=" + LedgerId.ToString() + " " +
                " AND VoucherId in (Select VoucherId from tblAccVoucherMain where VoucherDate< '" + dt.ToShortDateString() + "' )"; 
            double CurrBalance = ReportDAL.getVoucherBalance(Sql);
            Sql = "Select OpeningBalance from tblAccLedger where LedgerId=" + LedgerId.ToString() + "";
            double OpeningBalance = ReportDAL.getVoucherBalance(Sql);
            Sql = "Select CrDr from tblAccLedger where LedgerId=" + LedgerId.ToString() + "";
            string OpeningType = ReportDAL.getVoucherBalanceType(Sql);
            double Balance = 0;
            string TotalBalance = "";
            if (OpeningType == "Dr")
            {
                Balance = OpeningBalance + CurrBalance;
            }
            else if (OpeningType == "Cr")
            {
                Balance = -OpeningBalance + CurrBalance;
            }
            else
            {
                Balance = CurrBalance;
            }
            if (Balance >= 0)
            {
                TotalBalance = Balance.ToString() + "Dr";
            }
            else
            {
                Balance = -1 * Balance;
                TotalBalance = Balance.ToString() + "Cr";
            }
            return TotalBalance;

        }

        public void GetAllReport(string Sql)
        {
            

            this.GetReportCollection  = ReportDAL.GetReportData(Sql);

        }

       

}   



    //Trail Balance Report
public class TrailReport
{
    private List<TrailReport> _getAllReportData;

    private int _LedgerId;
    private string _LedgerName;

    private string _OpDebit;
    private string _OpCredit;

    private string _Debit;
    private string _Credit;

    private string _ClDebit;
    private string _ClCredit;

    public TrailReport()
    {
    }
    public int LedgerId
    {
        get { return _LedgerId; }
        set { _LedgerId = value; }
    }
    public string LedgerName
    {
        get { return _LedgerName; }
        set { _LedgerName = value; }
    }

    public string OpDebit
    {
        get { return _OpDebit; }
        set { _OpDebit = value; }
    }
    public string OpCredit
    {
        get { return _OpCredit; }
        set { _OpCredit = value; }
    }
    public string Debit
    {
        get { return _Debit; }
        set { _Debit = value; }
    }
    public string Credit
    {
        get { return _Credit; }
        set { _Credit = value; }
    }


    public string ClDebit
    {
        get { return _ClDebit; }
        set { _ClDebit = value; }
    }
    public string ClCredit
    {
        get { return _ClCredit; }
        set { _ClCredit = value; }
    }
    public List<TrailReport> GetReportCollection
    {
        get { return _getAllReportData; }
        set { _getAllReportData = value; }
    }


    public void GetTrailBalanceReport(DateTime fdt, DateTime tdt,string CompanyId)
    {
        this.GetReportCollection = ReportDAL.GetTrailBalanceReport(fdt, tdt,CompanyId );
    }


}



