using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for PLReport
/// </summary>
public class PLReport
{
    private List<PLReport> _getAllExpenseData;
    private List<PLReport> _getAllIncomeData;

    private string _Particulars;

    private string _LedAmount;
    private string _GroupAmount;

    public PLReport()
    {
    }
    public string Particulars
    {
        get { return _Particulars; }
        set { _Particulars = value; }
    }
    public string LedAmount
    {
        get { return _LedAmount; }
        set { _LedAmount = value; }
    }
    public string GroupAmount
    {
        get { return _GroupAmount; }
        set { _GroupAmount = value; }
    }
    public List<PLReport> GetExpenseCollection
    {
        get { return _getAllExpenseData; }
        set { _getAllExpenseData = value; }
    }
}

    //public List<PLReport> GetIncomeCollection
    //{
    //    get { return _getAllIncomeData; }
    //    set { _getAllIncomeData = value; }
    //}


//    public void GetPLExpenseReport(string CompanyId)
//    {
//        this.GetExpenseCollection = ReportDAL.GetPLExpenseReport(CompanyId);
//    }

//    public void GetPLIncomeReport(string CompanyId)
//    {
//        this.GetIncomeCollection = ReportDAL.GetPLIncomeReport(CompanyId );
//    }



//}



//public class BalanceSheetReport
//{
//    private List<BalanceSheetReport> _getAllAssetsData;
//    private List<BalanceSheetReport> _getAllLiabilitiesData;

//    private string _Particulars;

//    private string _LedAmount;
//    private string _GroupAmount;

//    public BalanceSheetReport()
//    {
//    }
//    public string Particulars
//    {
//        get { return _Particulars; }
//        set { _Particulars = value; }
//    }
//    public string LedAmount
//    {
//        get { return _LedAmount; }
//        set { _LedAmount = value; }
//    }
//    public string GroupAmount
//    {
//        get { return _GroupAmount; }
//        set { _GroupAmount = value; }
//    }
//    public List<BalanceSheetReport> GetAssetsCollection
//    {
//        get { return _getAllAssetsData; }
//        set { _getAllAssetsData = value; }
//    }

//    public List<BalanceSheetReport> GetLiabilitiesCollection
//    {
//        get { return _getAllLiabilitiesData; }
//        set { _getAllLiabilitiesData = value; }
//    }


//    public void GetAssetsReport(string CompanyId)
//    {
//        this.GetAssetsCollection = ReportDAL.GetAssetsReport(CompanyId );
//    }

//    public void GetLiabilitiesReport(string CompanyId)
//    {
//        //this.GetIncomeCollection = ReportDAL.GetPLIncomeReport();
//        this.GetLiabilitiesCollection = ReportDAL.GetLiabilitiesReport(CompanyId );
//    }

//    public double getNetProfit(string CompanyId)
//    {
//        return ReportDAL.NetProfit(CompanyId );
//    }

//}