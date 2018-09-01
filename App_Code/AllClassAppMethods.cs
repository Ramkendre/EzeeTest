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
using System.Data.SqlClient;

/// <summary>
/// Summary description for AllClassAppMethods
/// </summary>
public class AllClassAppMethods
{
    public AllClassAppMethods()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    CommonCode cc = new CommonCode();

    public string ClassSettingfunction(string AndroidClassSettingID, string strSession, string ClassID, string batch, string strSemister, string strClassTeacher, string mobileNo, string strEmail, string OwnerNo, string InstituteHeadMob, string FacultyMobNo, string studStatus, string smsStatus)
    {
        string str1 = string.Empty;
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspClassAppSettings";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@AndroidClassSettingID",AndroidClassSettingID),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@ClassID",Convert.ToInt16(ClassID)),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSemister",strSemister),
                            new SqlParameter("@strClassTeacher",strClassTeacher),
                            new SqlParameter("@mobileNo",mobileNo),
                            new SqlParameter("@strEmail",strEmail),
                            new SqlParameter("@loginPerson",OwnerNo),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                            new SqlParameter("@studentStatus",studStatus),
                            new SqlParameter("@smsStatus",smsStatus),
                        };
        sqlcommand.Parameters.AddRange(parameter);
        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            if (abs == 1)
            {
                string str = "select max(ClassSetting_id) FROM [DBeZeeOnlineExam].[dbo].[tblClassSetting] where [Class_Id]='" + Convert.ToInt16(ClassID) + "' and [Batch]='" + batch + "' and [InstituteHeadMob]='" + InstituteHeadMob + "'";
                str1 = cc.ExecuteScalar(str);
                return "1" + "*" + str1;
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string GetReferenaceMobNo(string OwnerNo)
    {
        string sqlQuery3 = "Select [RefMobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [mobileNo]='" + OwnerNo + "' and keyword='CLASSAPP'";
        DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);
        string s = null;
        if (dataset3.Tables[0].Rows.Count > 0)
        {
            s = dataset3.Tables[0].Rows[0]["RefMobileNo"].ToString();
        }
        return s;
    }

    public string StudentRegistrationFunction(string admissionNo, string admissionDate, string ClassID, string batch, string strSession, string firstName, string lastName, string fatherName, string parentMobileNo, string studMobileNo, string dob, string gender, string address, string wordno, string area, string city, string pincode, string AndroidClassSettingID, string AndroidStudentSNO, string OwnerNo, string InstituteHeadMob, string FacultyMobNo)
    {
        string str2 = string.Empty;
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspClassAppStudentRegistration";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@admissionNo",admissionNo),
                            new SqlParameter("@admissionDate",admissionDate),
                            new SqlParameter("@ClassID",ClassID),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@firstName",firstName),
                            new SqlParameter("@lastName",lastName),
                            new SqlParameter("@fatherName",fatherName),
                            new SqlParameter("@parentMobileNo",parentMobileNo),
                            new SqlParameter("@studMobileNo",studMobileNo),
                            new SqlParameter("@dob",dob),
                            new SqlParameter("@gender",gender),
                            new SqlParameter("@address",address),
                            new SqlParameter("@wordno",wordno),
                            new SqlParameter("@area",area),
                            new SqlParameter("@city",city),
                            new SqlParameter("@pincode",pincode),
                            new SqlParameter("@AndroidClassSettingID",AndroidClassSettingID),
                            new SqlParameter("@AndroidStudentSNO",AndroidStudentSNO),
                            new SqlParameter("@loginPerson",OwnerNo),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                        };
        sqlcommand.Parameters.AddRange(parameter);
        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            if (abs == 1)
            {
                string str = "SELECT MAX(SNO) FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister]";
                str2 = cc.ExecuteScalar(str);
                return "1" + "*" + str2;
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string FamilyDetailsFunction(string ClassID, string batch, string strSession, string firstName, string lastName, string fatherName, string relName, string Relation, string Age, string Occupation, string Education, string AndroidStudentSNO, string OwnerNo)
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspClassAppFamilyDetails";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@ClassID",ClassID),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@firstName",firstName),
                            new SqlParameter("@lastName",lastName),
                            new SqlParameter("@fatherName",fatherName),
                            new SqlParameter("@relName",relName),
                            new SqlParameter("@Relation",Relation),
                            new SqlParameter("@Age",Age),
                            new SqlParameter("@Occupation",Occupation),
                            new SqlParameter("@Education",Education),
                            new SqlParameter("@AndroidStudentSNO",AndroidStudentSNO),
                            new SqlParameter("@loginPerson",OwnerNo)
                        };
        sqlcommand.Parameters.AddRange(parameter);
        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            if (abs == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string ClassAppFeesDetailsFunction(string ClassID, string batch, string strSession, string firstName, string lastName, string fatherName, string strfeesDate, string receptno, string amount, string remark, string AndroidStudentSNO, string outofFeesDetails, string nextReminderDate, string OwnerNo, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspClassAppFeesDetails";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string fullName = firstName + " " + fatherName + " " + lastName;
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@ClassID",ClassID),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@FullName",fullName),
                            new SqlParameter("@firstName",firstName),
                            new SqlParameter("@lastName",lastName),
                            new SqlParameter("@fatherName",fatherName),
                            new SqlParameter("@strfeesDate",strfeesDate),
                            new SqlParameter("@receptno",receptno),
                            new SqlParameter("@amount",amount),
                            new SqlParameter("@remark",remark),
                            new SqlParameter("@AndroidStudentSNO",AndroidStudentSNO),
                            new SqlParameter("@outofTotalFees",outofFeesDetails),
                            new SqlParameter("@nextRemDate",nextReminderDate),
                            new SqlParameter("@loginPerson",OwnerNo),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                        };
        sqlcommand.Parameters.AddRange(parameter);

        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);

            if (abs == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string ClassAppAttendanceFunction(string ClassID, string batch, string strSession, string firstName, string lastName, string fatherName, string stud_present_absent, string AndroidStudentSNO, string attenDate, string OwnerNo, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "studentAttendanceSp";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@ClassID",ClassID),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@firstName",firstName),
                            new SqlParameter("@lastName",lastName),
                            new SqlParameter("@fatherName",fatherName),
                            new SqlParameter("@stud_present_absent",stud_present_absent),
                            new SqlParameter("@AndroidStudentSNO",AndroidStudentSNO),
                            new SqlParameter("@attenDate",attenDate),
                            new SqlParameter("@loginPerson",OwnerNo),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                        };
        sqlcommand.Parameters.AddRange(parameter);
        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            if (abs == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string TestDetailsFunction(string ClassID, string batch, string strSession, string firstName, string lastName, string fatherName, string TestNo, string TestName, string Topic, string OutOfmarks, string stud_mark, string Testdate, string AndroidStudentSNO, string OwnerNo, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspClassAppTestDetails";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@ClassID",ClassID),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@strSession",strSession),
                            new SqlParameter("@firstName",firstName),
                            new SqlParameter("@lastName",lastName),
                            new SqlParameter("@fatherName",fatherName),
                            new SqlParameter("@TestNo",TestNo),
                            new SqlParameter("@TestName",TestName),
                            new SqlParameter("@Topic",Topic),
                            new SqlParameter("@OutOfmarks",OutOfmarks),
                            new SqlParameter("@stud_mark",stud_mark),
                            new SqlParameter("@Testdate",Testdate),
                            new SqlParameter("@AndroidStudentSNO",AndroidStudentSNO),
                            new SqlParameter("@loginPerson",OwnerNo),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                        };
        sqlcommand.Parameters.AddRange(parameter);
        sqlcommand.Connection.Open();

        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            if (abs == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string GetAttendanceDetailsFunction(string referenceMoblie, string parentOwnerMobile)
    {
        string result = string.Empty;
        string SqlQuery1 = "(Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + referenceMoblie + "'";
        DataSet dataSet = cc.ExecuteDataset(SqlQuery1);

        if (dataSet.Tables[0].Rows.Count > 0)
        {
            for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
            {
                string sno = dataSet.Tables[0].Rows[a][0].ToString();
                string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[a].Rows[0][3].ToString();

                string SqlQuery2 = "  Select [attenDate],[Present] FROM [DBeZeeOnlineExam].[dbo].[tblAttendance] Where [StudentRegSNO]='" + sno + "'";
                DataSet dataSet2 = new DataSet();

                string attenDate = dataSet2.Tables[0].Rows[a][0].ToString();
                string presenty = dataSet2.Tables[0].Rows[a][1].ToString();

                result += attenDate + "*" + presenty + "*" + fullName + "*";
            }
        }
        return result.Substring(0, result.Length - 1);
    }

    public string InsertExamScheduleFunction(string classId, string batch, string session, string date, string subject, string marks, string startTime, string endTime, string loginId, string examName, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.CommandText = "uspInsertClassAppExamSchedule";
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@classId",classId),
                            new SqlParameter("@batch",batch),
                            new SqlParameter("@session",session),
                            new SqlParameter("@examDate",date),
                            new SqlParameter("@subject",subject),
                            new SqlParameter("@marks",marks),
                            new SqlParameter("@startTime",startTime),
                            new SqlParameter("@endTime",endTime),
                            new SqlParameter("@loginId",loginId),
                            new SqlParameter("@examName",examName),
                            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                            new SqlParameter("@FacultyMobNo",FacultyMobNo),
                        };
        sqlcommand.Parameters.AddRange(parameter);

        SqlParameter p = sqlcommand.CreateParameter();
        p.Direction = ParameterDirection.ReturnValue;
        p.ParameterName = "status";
        sqlcommand.Parameters.Add(p);

        sqlcommand.Connection.Open();
        try
        {
            int status = sqlcommand.ExecuteNonQuery();
            int abs = Math.Abs(status);
            status = abs;
            object st = sqlcommand.Parameters["status"].Value;
            return st.ToString();
        }
        catch
        {
            return "0";
        }
        finally
        {
            sqlcommand.Connection.Close();
        }
    }

    public string InsertDailyInstruction(string typeofInstruction, string date, string instructionDetails, string teacherMobNo, string ownerMobNo, string classId, string batch, string Session, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        cmd.Connection.Open();
        SqlParameter[] par = new SqlParameter[]
        {
            new SqlParameter("@typeofInstruction",typeofInstruction),
            new SqlParameter("@date",date),
            new SqlParameter("@instructionDetails",instructionDetails),
            new SqlParameter("@teacherMobNo",teacherMobNo),
            new SqlParameter("@ownerMobNo",ownerMobNo),
            new SqlParameter("@classId",classId),
            new SqlParameter("@batch",batch),
            new SqlParameter("@Session",Session),
            new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
            new SqlParameter("@FacultyMobNo",FacultyMobNo),
        };
        cmd.Parameters.AddRange(par);

        //-------Crete New Para for return Value-----------

        SqlParameter p = cmd.CreateParameter();
        p.Direction = ParameterDirection.ReturnValue;
        p.ParameterName = "Status";
        cmd.Parameters.Add(p);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "uspInsertClassAppDailyInstruction";

        try
        {
            int Status = cmd.ExecuteNonQuery();
            object st = cmd.Parameters["Status"].Value;
            return st.ToString();
        }
        catch
        {
            return "0";
        }
        finally
        {
            cmd.Connection.Close();
        }
    }

    public string InsertEvents(string typeofEvents, string eventDetails, string date, string topic, string teacherMobNo, string ownerMobNo, string classId, string batch, string Session, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        cmd.Connection.Open();
        SqlParameter[] par = new SqlParameter[] 
        {
                new SqlParameter("@typeofEvents",typeofEvents),new SqlParameter("@eventDetails",eventDetails),
                new SqlParameter("@date",date),new SqlParameter("@topic",topic),
                new SqlParameter("@teacherMobNo",teacherMobNo),new SqlParameter("@ownerMobNo",ownerMobNo),
                new SqlParameter("@classId",classId),new SqlParameter("@batch",batch),
             
                new SqlParameter("@Session",Session),
                new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                new SqlParameter("@FacultyMobNo",FacultyMobNo),
        };
        cmd.Parameters.AddRange(par);

        SqlParameter p = cmd.CreateParameter();
        p.Direction = ParameterDirection.ReturnValue;
        p.ParameterName = "Status";
        cmd.Parameters.Add(p);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "uspInsertClassAppEvents";
        try
        {
            int Status = cmd.ExecuteNonQuery();
            int abs = Math.Abs(Status);
            Status = abs;
            object st = cmd.Parameters["Status"].Value;
            return st.ToString();
        }
        catch
        {
            return "0";
        }
        finally
        {
            cmd.Connection.Close();
        }
    }

    public string InsertSubjectNotes(string date, string chapter, string topic, string subjectNotes, string subject, string teacherMobNo, string ownerMobNo, string classId, string batch, string Session, string InstituteHeadMob, string FacultyMobNo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        cmd.Connection.Open();
        SqlParameter[] par = new SqlParameter[] 
        {
                new SqlParameter("@date",date),new SqlParameter("@chapter",chapter),
                new SqlParameter("@topic",topic),new SqlParameter("@subjectNotes",subjectNotes),
                new SqlParameter("@subject",subject),new SqlParameter("@teacherMobNo",teacherMobNo),
                new SqlParameter("@ownerMobNo",ownerMobNo),new SqlParameter("@classId",classId),
                new SqlParameter("@batch",batch),
                new SqlParameter("@Session",Session),
                new SqlParameter("@InstituteHeadMob",InstituteHeadMob),
                new SqlParameter("@FacultyMobNo",FacultyMobNo),
        };
        cmd.Parameters.AddRange(par);

        SqlParameter p = cmd.CreateParameter();
        p.Direction = ParameterDirection.ReturnValue;
        p.ParameterName = "Status";
        cmd.Parameters.Add(p);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "uspInsertClassAppSubjectNotes";
        try
        {
            int Status = cmd.ExecuteNonQuery();
            int abs = Math.Abs(Status);
            Status = abs;
            object st = cmd.Parameters["Status"].Value;
            return st.ToString();
        }
        catch
        {
            return "0";
        }
        finally
        {
            cmd.Connection.Close();
        }
    }

    public string InsertStudentRegForTrainingClass(string TrainingClassID, string batch, string CourseCode, string TrainerMobno, string IhMobno)
    {
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        string SQL = string.Empty;
        int maxAdmNo;
        try
        {
            string Fname = string.Empty; string Lname = string.Empty; string Mname = string.Empty; string Bod = string.Empty;
            string gender = string.Empty; string Address = string.Empty; string mobno = string.Empty; string date = string.Empty;
            string IhMobNo = string.Empty;

            SqlQry = "Select [FirstName],[LastName],[MiddleName],[BirthDate],[Gender],[PlaceTaluka],[PermAddress],[userMobileNumber],[InsertDate],[InsertBy]" +
                      "from [tblEmpPersonalDetails] where [InsertBy]='" + IhMobno + "' and [userMobileNumber]='" + TrainerMobno + "'";
            ds = cc.ExecuteDataset(SqlQry);

            Fname = ds.Tables[0].Rows[0]["FirstName"].ToString();
            Lname = ds.Tables[0].Rows[0]["LastName"].ToString();
            Mname = ds.Tables[0].Rows[0]["MiddleName"].ToString();
            Bod = ds.Tables[0].Rows[0]["BirthDate"].ToString();
            gender = ds.Tables[0].Rows[0]["Gender"].ToString();
            Address = ds.Tables[0].Rows[0]["PermAddress"].ToString();
            mobno = ds.Tables[0].Rows[0]["userMobileNumber"].ToString();
            date = ds.Tables[0].Rows[0]["InsertDate"].ToString();
            IhMobNo = ds.Tables[0].Rows[0]["InsertBy"].ToString();

            string sql = "Select [ClassSetting_id] from [tblClassSetting] where [InstituteHeadMob]='" + IhMobno + "' and [Batch]='" + batch + "' and [Class_Id]='" + TrainingClassID + "'";
            DataSet Ds = cc.ExecuteDataset(sql);
            string ClassSettingid = Convert.ToString(Ds.Tables[0].Rows[0]["ClassSetting_id"]);
            if (ClassSettingid == "")
            {
                return "Please Enter the Class Setting Deatils";
            }
            if (Ds.Tables[0].Rows.Count > 0)
            {
                string SQl = "select Adm_No as MaxAdmNo from [tblStudentRegister] where [InstituteHeadMob]='" + IhMobno + "' and [Stud_MobNo]='" + TrainerMobno + "'"; //or [Parent_MobNo]='"+ TrainerMobno +"'";
                ds = cc.ExecuteDataset(SQl);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SQL = "update [tblStudentRegister] set [adm_date]='" + date + "',[DOB]='" + Bod + "',[Stud_MobNo]='" + TrainerMobno + "',[Parent_MobNo]='" + TrainerMobno + "',[StudAddress]='" + Address + "',[Gender]='" + gender + "',[First_Name]='" + Fname + "',[Last_Name]='" + Lname + "',[Father_Name]='" + Fname + "',[ClassSetting_id]='" + ClassSettingid + "',[LoginId]='" + IhMobNo + "' " +
                          "where [InstituteHeadMob]='" + IhMobno + "' and [Stud_MobNo]='" + TrainerMobno + "'"; //or [Parent_MobNo]='" + TrainerMobno + "'";
                    cc.ExecuteNonQuery(SQL);
                }
                else
                {
                    string sqlAdmNo = "select top 1(Adm_No) as MaxAdmNo from [tblStudentRegister] where [InstituteHeadMob]='" + IhMobno + "' order by Adm_No DESC";
                    ds = cc.ExecuteDataset(sqlAdmNo);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQL = "insert into [tblStudentRegister] ([Adm_No],[adm_date],[DOB],[Stud_MobNo],[Parent_MobNo],[StudAddress],[Gender],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[InstituteHeadMob],[LoginId],[FacultyMobNo])" +
                             "values('" + "1" + "','" + date + "','" + Bod + "','" + mobno + "','" + mobno + "','" + Address + "','" + gender + "','" + Fname + "','" + Lname + "','" + Mname + "','" + ClassSettingid + "','" + IhMobno + "','" + IhMobNo + "','0')";
                        cc.ExecuteNonQuery(SQL);
                    }
                    else
                    {
                        maxAdmNo = Convert.ToInt32(ds.Tables[0].Rows[0]["MaxAdmNo"]);
                        maxAdmNo += 1;

                        SQL = "insert into [tblStudentRegister] ([Adm_No],[adm_date],[DOB],[Stud_MobNo],[Parent_MobNo],[StudAddress],[Gender],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[InstituteHeadMob],[LoginId],[FacultyMobNo])" +
                                     "values('" + maxAdmNo + "','" + date + "','" + Bod + "','" + mobno + "','" + mobno + "','" + Address + "','" + gender + "','" + Fname + "','" + Lname + "','" + Mname + "','" + ClassSettingid + "','" + IhMobno + "','" + IhMobNo + "','0')";
                        cc.ExecuteNonQuery(SQL);
                    }
                }
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }
}
