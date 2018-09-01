using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

/// <summary>
/// Summary description for InsertChaptersTopics
/// </summary>
/// 

public class InsertChaptersTopics
{
    public InsertChaptersTopics()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    SqlCommand sqlCommand = new SqlCommand();
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    SqlParameter[] sqlParameter = null;
    DataSet dataset = new DataSet();

    #region Class_Fields

    int _snoId;
    int _groupofExam;
    string _groupofExamName;
    int _typeofExam;
    string _typeofExamName;
    int _stateId;
    string _stateName;
    int _districtId;
    string _districtName;
    int _boardId;
    string _boardName;
    int _universityId;
    string _universityName;
    string _medium;
    int _classId;
    string _className;
    int _subjectId;
    string _subjectName;
    int _publicationId;
    string _publicationName;
    int _chapterId;
    string _chapterName;
    int _topicId;
    string _topicName;
    string _loginUser;

    #endregion

    #region PUBLIC PROPERTIES

    public int SnoId
    {
        get { return this._snoId; }
        set { this._snoId = value; }
    }

    public int GroupofExam
    {
        get { return this._groupofExam; }
        set { this._groupofExam = value; }
    }

    public string GroupofExamName
    {
        get { return this._groupofExamName; }
        set { this._groupofExamName = value; }
    }

    public int TypeofExam
    {
        get { return this._typeofExam; }
        set { this._typeofExam = value; }
    }

    public string TypeofExamName
    {
        get { return this._typeofExamName; }
        set { this._typeofExamName = value; }
    }

    public int StateId
    {
        get { return this._stateId; }
        set { this._stateId = value; }
    }

    public string StateName
    {
        get { return this._stateName; }
        set { this._stateName = value; }
    }

    public int DistrictId
    {
        get { return this._districtId; }
        set { this._districtId = value; }
    }

    public string DistrictName
    {
        get { return this._districtName; }
        set { this._districtName = value; }
    }

    public int BoardId
    {
        get { return this._boardId; }
        set { this._boardId = value; }
    }

    public string BoardName
    {
        get { return this._boardName; }
        set { this._boardName = value; }
    }

    public int UniversityId
    {
        get { return this._universityId; }
        set { this._universityId = value; }
    }

    public string UniversityName
    {
        get { return this._universityName; }
        set { this._universityName = value; }
    }

    public string Medium
    {
        get { return this._medium; }
        set { this._medium = value; }
    }

    public int ClassId
    {
        get { return this._classId; }
        set { this._classId = value; }
    }

    public string ClassName
    {
        get { return this._className; }
        set { this._className = value; }
    }

    public int SubjectId
    {
        get { return this._subjectId; }
        set { this._subjectId = value; }
    }

    public string SubjectName
    {
        get { return this._subjectName; }
        set { this._subjectName = value; }
    }

    public int PublicationId
    {
        get { return this._publicationId; }
        set { this._publicationId = value; }
    }

    public string PublicationName
    {
        get { return this._publicationName; }
        set { this._publicationName = value; }
    }

    public int ChapterId
    {
        get { return this._chapterId; }
        set { this._chapterId = value; }
    }

    public string ChapterName
    {
        get { return this._chapterName; }
        set { this._chapterName = value; }
    }

    public int TopicId
    {
        get { return this._topicId; }
        set { this._topicId = value; }
    }

    public string TopicName
    {
        get { return this._topicName; }
        set { this._topicName = value; }
    }

    public string LoginUser
    {
        get { return this._loginUser; }
        set { this._loginUser = value; }
    }

    #endregion

    #region PUBLIC CLASS METHODS

    public int InsertChapterNames()
    {
        try
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspInsertChapterName";
            sqlCommand.Connection = sqlConnection;

            sqlParameter = new SqlParameter[]
        {
            new SqlParameter("@groupofExam",this._groupofExam),
            new SqlParameter("@groupofExamName",this._groupofExamName),
            new SqlParameter("@typeofExam",this._typeofExam),
            new SqlParameter("@typeofExamName",this._typeofExamName),
            new SqlParameter("@stateId",this._stateId),
            new SqlParameter("@stateName",this._stateName),
            new SqlParameter("@districtId",this._districtId),
            new SqlParameter("@districtName",this._districtName),
            new SqlParameter("@boardId",this._boardId),
            new SqlParameter("@boardName",this._boardName),
            new SqlParameter("@universityId",this._universityId),
            new SqlParameter("@universityName",this._universityName),
            new SqlParameter("@medium",this._medium),
            new SqlParameter("@classId",this._classId),
            new SqlParameter("@className",this._className),
            new SqlParameter("@subjectId",this._subjectId),
            new SqlParameter("@subjectName",this._subjectName),
            new SqlParameter("@publicationId",this._publicationId),
            new SqlParameter("@publicationName",this._publicationName),
            new SqlParameter("@chapterId",this._chapterId),
            new SqlParameter("@chapterName",this._chapterName),
            new SqlParameter("@topicId",this._topicId),
            new SqlParameter("@topicName",this._topicName),
            new SqlParameter("@insertedBy",this._loginUser)
        };

            sqlCommand.Parameters.AddRange(sqlParameter);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        catch
        {
            return 105;
        }

        return 106;
    }

    public int UpdateChapterName()
    {
        try
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspUpdateChapterName";
            sqlCommand.Connection = sqlConnection;

            sqlParameter = new SqlParameter[]
        {
            new SqlParameter("@snoId",this._snoId),
            new SqlParameter("@groupofExam",this._groupofExam),
            new SqlParameter("@groupofExamName",this._groupofExamName),
            new SqlParameter("@typeofExam",this._typeofExam),
            new SqlParameter("@typeofExamName",this._typeofExamName),
            new SqlParameter("@stateId",this._stateId),
            new SqlParameter("@stateName",this._stateName),
            new SqlParameter("@districtId",this._districtId),
            new SqlParameter("@districtName",this._districtName),
            new SqlParameter("@boardId",this._boardId),
            new SqlParameter("@boardName",this._boardName),
            new SqlParameter("@universityId",this._universityId),
            new SqlParameter("@universityName",this._universityName),
            new SqlParameter("@medium",this._medium),
            new SqlParameter("@classId",this._classId),
            new SqlParameter("@className",this._className),
            new SqlParameter("@subjectId",this._subjectId),
            new SqlParameter("@subjectName",this._subjectName),
            new SqlParameter("@publicationId",this._publicationId),
            new SqlParameter("@publicationName",this._publicationName),
            new SqlParameter("@chapterId",this._chapterId),
            new SqlParameter("@chapterName",this._chapterName),
            new SqlParameter("@topicId",this._topicId),
            new SqlParameter("@topicName",this._topicName),
            new SqlParameter("@modifyBy",this._loginUser)
        };

            sqlCommand.Parameters.AddRange(sqlParameter);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        catch
        {
            return 105;
        }

        return 106;
    }

    public int DeleteChapterName()
    {
        try
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspDeleteChapterName";
            sqlCommand.Connection = sqlConnection;

            sqlParameter = new SqlParameter[] { 
            new SqlParameter("@snoId",this._snoId)
            };

            sqlCommand.Parameters.AddRange(sqlParameter);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }
        catch 
        {
            return 105;
        }
        return 106;
    }


    public DataSet GetChapterDataBySnoId()
    {
        try
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetChapterDataBySnoId";
            sqlCommand.Connection = sqlConnection;

            sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@snoId",this._snoId)
            };

            sqlCommand.Parameters.AddRange(sqlParameter);
            sqlCommand.Connection.Open();

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataset);
            
            sqlCommand.Connection.Close();
        }
        catch { }

        return dataset;
    }

    #endregion
}