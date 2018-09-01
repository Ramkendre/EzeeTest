using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
/// <summary>
/// Summary description for BindQuestionsToGridDAL
/// </summary>
public class BindQuestionsToGridDAL
{
	public BindQuestionsToGridDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    DataSet ds = new DataSet();

    public DataSet BindQuestionsToGrid(BindQuestionsToGridBAL objBindQuestionsToGridBAL)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                string Sql = "Select TOP 4 tblQuestionAccess.SNO,Question,TypeofDB,Sellanguage,QType,tblItemValue.Name as TypeofQues From tblQuestionAccess inner join tblItemValue on tblQuestionAccess.TypeofQues=tblItemValue.ItemValueId  where QType=0 union Select TOP 4 tblQuestionAccess.SNO,Question,TypeofDB,Sellanguage,QType,tblItemValue.Name as TypeofQues From tblQuestionAccess inner join tblItemValue on tblQuestionAccess.TypeofQues=tblItemValue.ItemValueId where QType=1 union Select TOP 4 tblQuestionAccess.SNO,Question,TypeofDB,Sellanguage,QType,tblItemValue.Name as TypeofQues From tblQuestionAccess inner join tblItemValue on tblQuestionAccess.TypeofQues=tblItemValue.ItemValueId where QType=2 order by QType asc ";

               

                
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        return ds;

    }



}
