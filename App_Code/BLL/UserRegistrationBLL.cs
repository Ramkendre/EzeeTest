﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserRegistrationBLL
/// </summary>
public class UserRegistrationBLL
{
	UserRegistrationDAL urUserRegDALObj = new UserRegistrationDAL();

    public UserRegistrationBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataTable dtPasswordDtl = new DataTable();
    private int _srNo;
    private string _usrUserId;
    private string _usrUserName;
    private string _usrPasssword;
    private string _usrChangePassword;
    private string _usrFullName;
    private string _usrFirstName;
    private string _usrMiddleName;
    private string _usrLastName;
    private string _usrGender;
    private string _usrMobileNo;
    private int _usrDND;
    private string _usrArea;
    private int _usrAreaId;
    private string _usrEmailId;
    private string _usrAddress;
    private int _usrStateId;
    private int _usrDistrictId;
    private int _usrCityId;
    private string _usrCityName;
    private string _usrPIN;
    private string _usrPhoneNo;
    private string _usrAltMobileNo;
    private string _usrDOB;
    private int _usrHighestQualification;
    private int _usrBoardUniversity;
    private string _usrBoardUniversityName;
    private int _usrProfession;
    private string _usrProfessionName;
    private int _usrIndustry;
    private string _usrCategory;
    private int _Age;
    private string _usrPrefix;
    private string _usrPostfix;
    private string _usrInfix;
    private string _senderid;
    private string _id;
    private DateTime _usrCreationDate;
    private int _usrreligion;
    private string _wardno;
    private string _namevosotorlist;
    private string _strDevId;


    public string Namevosotorlist
    {
        get { return _namevosotorlist; }
        set { _namevosotorlist = value; }
    }
    private string _RationCard;

    public string RationCard
    {
        get { return _RationCard; }
        set { _RationCard = value; }
    }
    private string _OwnHouse;

    public string OwnHouse
    {
        get { return _OwnHouse; }
        set { _OwnHouse = value; }
    }
    private string _Pancard;

    public string Pancard
    {
        get { return _Pancard; }
        set { _Pancard = value; }
    }
    private string _SeniorCitizen;

    public string SeniorCitizen
    {
        get { return _SeniorCitizen; }
        set { _SeniorCitizen = value; }
    }
    private string _RailwayPass;

    public string RailwayPass
    {
        get { return _RailwayPass; }
        set { _RailwayPass = value; }
    }
    private string _Handicap;

    public string Handicap
    {
        get { return _Handicap; }
        set { _Handicap = value; }
    }
    private string _AdharNidhi;

    public string AdharNidhi
    {
        get { return _AdharNidhi; }
        set { _AdharNidhi = value; }
    }
    private string _SAnjayGandhiYojana;

    public string SAnjayGandhiYojana
    {
        get { return _SAnjayGandhiYojana; }
        set { _SAnjayGandhiYojana = value; }
    }
    private string _anyscholorship;

    public string Anyscholorship
    {
        get { return _anyscholorship; }
        set { _anyscholorship = value; }
    }
    private string _joingroup;

    public string Joingroup
    {
        get { return _joingroup; }
        set { _joingroup = value; }
    }

    public string Wardno
    {
        get { return _wardno; }
        set { _wardno = value; }
    }
    private string _marriagedt;

    public string Marriagedt
    {
        get { return _marriagedt; }
        set { _marriagedt = value; }
    }
    private string _jobplace;

    public string Jobplace
    {
        get { return _jobplace; }
        set { _jobplace = value; }
    }
    private string _votterlist;

    public string Votterlist
    {
        get { return _votterlist; }
        set { _votterlist = value; }
    }


    public int Usrreligion
    {
        get { return _usrreligion; }
        set { _usrreligion = value; }
    }
    private string _caste;

    public string Caste
    {
        get { return _caste; }
        set { _caste = value; }
    }
    private int _usrcastecategory;

    public int Usrcastecategory
    {
        get { return _usrcastecategory; }
        set { _usrcastecategory = value; }
    }

    public DateTime UsrCreationDate
    {
        get { return _usrCreationDate; }
        set { _usrCreationDate = value; }
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _customername;

    public string Customername
    {
        get { return _customername; }
        set { _customername = value; }
    }
    private string _customermobileno;

    public string Customermobileno
    {
        get { return _customermobileno; }
        set { _customermobileno = value; }
    }
    private string _transferdate;

    public string Transferdate
    {
        get { return _transferdate; }
        set { _transferdate = value; }
    }

    private string _usrSocialDesignation;

    public string UsrSocialDesignation
    {
        get { return _usrSocialDesignation; }
        set { _usrSocialDesignation = value; }
    }
    private string _transbal;

    public string Transbal
    {
        get { return _transbal; }
        set { _transbal = value; }
    }
    private string _prombal;

    public string Prombal
    {
        get { return _prombal; }
        set { _prombal = value; }
    }
    private string _validfrom;

    public string Validfrom
    {
        get { return _validfrom; }
        set { _validfrom = value; }
    }
    private string _validupto;

    public string Validupto
    {
        get { return _validupto; }
        set { _validupto = value; }
    }

    private string _frmmobileno;

    public string Frmmobileno
    {
        get { return _frmmobileno; }
        set { _frmmobileno = value; }
    }


    public string Senderid
    {
        get { return _senderid; }
        set { _senderid = value; }
    }

    public string UsrInfix
    {
        get { return _usrInfix; }
        set { _usrInfix = value; }
    }

    public string UsrPostfix
    {
        get { return _usrPostfix; }
        set { _usrPostfix = value; }
    }

    private string _usrCompanyName;
    private string _usrCarrerSkill;
    private string _usrCarrerInterest;
    private string _usrIdealMatch;
    private string _usrBestFeature;
    private string _usrHeight;
    private string _usrBuild;
    private string _usrPoliticalView;
    private int _usrMembershipPolitical;
    private int _usrMembershipSocial;
    private string _usrMembershipPoliticalText;
    private string _usrmembershipSocialText;
    private string _usrBooks;
    private string _usrMusic;
    private int _usrActive;
    private int _usrLogged;
    private string _tmpProfilePhoto;
    private string _usrProfilePhoto;
    private int _usrTermCond;
    private string _usrRecentVisitor;
    private string _usrRecentVisitor1;
    private string _usrRecentVisitorName;
    private int _usrControlMobileNo;

    private string _frnrelUserId;
    private string _frnrelFriendId;
    private string _frnrelFrnRelName;
    private string _frnrelRelation;
    private string _frnrelPrefix;
    private string _frnrelfrirelId;

    public string FrnrelfrirelId
    {
        get { return _frnrelfrirelId; }
        set { _frnrelfrirelId = value; }
    }
  

    


   
    private string _frnrelSendMsg;
    private string _frnrelGroup;

    private string _OfficeNo;
    private string _FaxNo;
    private string _Website;

    private string _KeyWord;
    private string _LongCodeGrSMS;
    private string _UsrGrNames;
    private int _usrPKval;
    private string  _JoinFlagProp;

    private string _usrMessageString;


    private string _usrFIlfptr;
    private string _usrFIname1;
    private string _usrFIgender1;
    private string _usrFIschool1;
    private string _usrFIclass1;
    private string _usrFIrollNo1;
    private string _usrFIname2;
    private string _usrFIgender2;
    private string _usrFIschool2;
    private string _usrFIclass2;
    private string _usrFIrollNo2;
    private string _usrFIname3;
    private string _usrFIgender3;
    private string _usrFIschool3;
    private string _usrFIclass3;
    private string _usrFIrollNo3;

    private List<UserRegistrationBLL> _getAllUser;
    private List<UserRegistrationBLL> _getSelectedUser;
    private List<UserRegistrationBLL> _getLoginUserDeails;
    private List<UserRegistrationBLL> _getUserInitialProfile;
    private List<UserRegistrationBLL> _getUserRegistrationSMSInfo;
    private List<UserRegistrationBLL> _getUserContactInfo;
    private List<UserRegistrationBLL> _getUserProfessionInfo;
    private List<UserRegistrationBLL> _getUserSocialInfo;
    private List<UserRegistrationBLL> _getUserFriendAll;
    private List<UserRegistrationBLL> _getFriendRelativeByMob;
    private List<UserRegistrationBLL> _getFriendRelativeById;
    private List<UserRegistrationBLL> _getUserRecentVisitorId;
    private List<UserRegistrationBLL> _getUserRecentVisitorName;



    public string UsrPrefix
    {
        get { return _usrPrefix; }
        set { _usrPrefix = value; }
    }
    public string usrMessageString
    {
        get { return _usrMessageString; }
        set { _usrMessageString = value; }
    }

    public string usrFIlfptr
    {
        get { return _usrFIlfptr; }
        set { _usrFIlfptr = value; }
    }

    public string usrFIname1
    {
        get { return _usrFIname1; }
        set { _usrFIname1 = value; }
    }
    public string usrFIgender1
    {
        get { return _usrFIgender1; }
        set { _usrFIgender1 = value; }
    }
    public string usrFIschool1
    {
        get { return _usrFIschool1; }
        set { _usrFIschool1 = value; }
    }
    public string usrFIclass1
    {
        get { return _usrFIclass1; }
        set { _usrFIclass1 = value; }
    }
    public string usrFIrollNo1
    {
        get { return _usrFIrollNo1; }
        set { _usrFIrollNo1 = value; }
    }
    public string usrFIname2
    {
        get { return _usrFIname2; }
        set { _usrFIname2 = value; }
    }
    public string usrFIgender2
    {
        get { return _usrFIgender2; }
        set { _usrFIgender2 = value; }
    }
    public string usrFIschool2
    {
        get { return _usrFIschool2; }
        set { _usrFIschool2 = value; }
    }
    public string usrFIclass2
    {
        get { return _usrFIclass2; }
        set { _usrFIclass2 = value; }
    }
    public string usrFIrollNo2
    {
        get { return _usrFIrollNo2; }
        set { _usrFIrollNo2 = value; }
    }
    public string usrFIname3
    {
        get { return _usrFIname3; }
        set { _usrFIname3 = value; }
    }
    public string usrFIgender3
    {
        get { return _usrFIgender3; }
        set { _usrFIgender3 = value; }
    }
    public string usrFIschool3
    {
        get { return _usrFIschool3; }
        set { _usrFIschool3 = value; }
    }
    public string usrFIclass3
    {
        get { return _usrFIclass3; }
        set { _usrFIclass3 = value; }
    }
    public string usrFIrollNo3
    {
        get { return _usrFIrollNo3; }
        set { _usrFIrollNo3 = value; }
    }








    public int usrDND
    {
        get { return _usrDND; }
        set { _usrDND = value; }
    
    }

    public int srNo
    {
        get
        {
            return _srNo;
        }
        set
        {
            _srNo = value;
        }
    }
    public string JoinFlagProp
    {
        get { return _JoinFlagProp; }
        set { _JoinFlagProp = value; }
    
    }
    public int usrPKval
    {
        get { return _usrPKval; }
        set { _usrPKval = value; }
    }
    public string usrKeyWord
    {
        get { return _KeyWord; }
        set { _KeyWord = value; }
    
    }
    public string UsrGroupNames
    {
        get { return _UsrGrNames; }
        set { _UsrGrNames = value; }
    }
    public string longCodegrSMS
    {
        get { return _LongCodeGrSMS; }
        set { _LongCodeGrSMS = value; }
     
    }

    public string usrUserId
    {
        get
        {
            return _usrUserId;
        }
        set
        {
            _usrUserId = value;
        }
    }

    public string usrCityName
    {
        get { return _usrCityName; }
        set { _usrCityName = value; }
    
    }

    public string usrUserName
    {
        get
        {
            return _usrUserName;
        }
        set
        {
            _usrUserName = value;
        }
    }

    public string usrPassword
    {
        get
        {
            return _usrPasssword;
        }
        set
        {
            _usrPasssword = value;
        }
    }

    public string usrChangePassword
    {
        get
        {
            return _usrChangePassword;
        }
        set
        {
            _usrChangePassword = value;
        }
    }

    public string usrFullName
    {
        get
        {
            return _usrFullName;
        }
        set
        {
            _usrFullName = value;
        }
    }

    public string usrFirstName
    {
        get
        {
            return _usrFirstName;
        }
        set
        {
            _usrFirstName = value;
        }
    }

    public string usrMiddleName
    {
        get
        {
            return _usrMiddleName;
        }
        set
        {
            _usrMiddleName = value;
        }
    }

    public string usrLastName
    {
        get
        {
            return _usrLastName;
        }
        set
        {
            _usrLastName = value;
        }
    }

    public string usrGender
    {
        get
        {
            return _usrGender;
        }
        set
        {
            _usrGender = value;
        }
    }

    public string usrCategory
    {
        get
        {
            return _usrCategory;
        }
        set
        {
            _usrCategory = value;
        }
    }
    public string usrMobileNo
    {
        get
        {
            return _usrMobileNo;
        }
        set
        {
            _usrMobileNo = value;
        }
    }

    public string usrArea
    {
        get
        {
            return _usrArea;
        }
        set
        {
            _usrArea = value;
        }
    }

    public int usrAreaId
    {
        get
        {
            return _usrAreaId;
        }
        set
        {
            _usrAreaId = value;
        }
    }

    public int Age
    {
        get
        {
            return _Age;
        }
        set
        {
            _Age = value;
        }
    }

    public string usrEmailId
    {
        get
        {
            return _usrEmailId;
        }
        set
        {
            _usrEmailId = value;
        }
    }

    public string usrAddress
    {
        get
        {
            return _usrAddress;
        }
        set
        {
            _usrAddress = value;
        }
    }

    public int usrStateId
    {
        get
        {
            return _usrStateId;
        }
        set
        {
            _usrStateId = value;
        }
    }

    public int usrDistrictId
    {
        get
        {
            return _usrDistrictId;
        }
        set
        {
            _usrDistrictId = value;
        }
    }


    public int usrCityId
    {
        get
        {
            return _usrCityId;
        }
        set
        {
            _usrCityId = value;
        }
    }

    public string usrPIN
    {
        get
        {
            return _usrPIN;
        }
        set
        {
            _usrPIN = value;
        }
    }

    public string usrPhoneNo
    {
        get
        {
            return _usrPhoneNo;
        }
        set
        {
            _usrPhoneNo = value;
        }
    }

    public string usrAltMobileNo
    {
        get
        {
            return _usrAltMobileNo;
        }
        set
        {
            _usrAltMobileNo = value;
        }
    }

    public string usrDOB
    {
        get
        {
            return _usrDOB;
        }
        set
        {
            _usrDOB = value;
        }
    }

    public int usrHighestQualification
    {
        get
        {
            return _usrHighestQualification;
        }
        set
        {
            _usrHighestQualification = value;
        }
    }

    public int usrBoardUniversity
    {
        get
        {
            return _usrBoardUniversity;
        }
        set
        {
            _usrBoardUniversity = value;
        }
    }

    public string usrBoardUniversityName
    {
        get
        {
            return _usrBoardUniversityName;
        }
        set
        {
            _usrBoardUniversityName = value;
        }
    }

    public int usrProfession
    {
        get
        {
            return _usrProfession;
        }
        set
        {
            _usrProfession = value;
        }
    }

    public string usrProfessionName
    {
        get
        {
            return _usrProfessionName;
        }
        set
        {
            _usrProfessionName = value;
        }
    }

    public int usrIndustry
    {
        get
        {
            return _usrIndustry;
        }
        set
        {
            _usrIndustry = value;
        }
    }



    public string usrCompanyName
    {
        get
        {
            return _usrCompanyName;
        }
        set
        {
            _usrCompanyName = value;
        }
    }

    public string usrCarrerSkill
    {
        get
        {
            return _usrCarrerSkill;
        }
        set
        {
            _usrCarrerSkill = value;
        }
    }

    public string usrCarrerInterest
    {
        get
        {
            return _usrCarrerInterest;
        }
        set
        {
            _usrCarrerInterest = value;
        }
    }

    public string usrIdealMatch
    {
        get
        {
            return _usrIdealMatch;
        }
        set
        {
            _usrIdealMatch = value;
        }
    }

    public string usrBestFeature
    {
        get
        {
            return _usrBestFeature;
        }
        set
        {
            _usrBestFeature = value;
        }
    }

    public string usrHeight
    {
        get
        {
            return _usrHeight;
        }
        set
        {
            _usrHeight = value;
        }
    }

    public string usrBuild
    {
        get
        {
            return _usrBuild;
        }
        set
        {
            _usrBuild = value;
        }
    }

    public string usrPoliticalView
    {
        get
        {
            return _usrPoliticalView;
        }
        set
        {
            _usrPoliticalView = value;
        }
    }

    public string usrBooks
    {
        get
        {
            return _usrBooks;
        }
        set
        {
            _usrBooks = value;
        }
    }

    public string usrMusic
    {
        get
        {
            return _usrMusic;
        }
        set
        {
            _usrMusic = value;
        }
    }

    public int usrMemebrshipPolitical
    {
        get
        {
            return _usrMembershipPolitical;
        }
        set
        {
            _usrMembershipPolitical = value;
        }
    }

    public int usrMembershipSocial
    {
        get
        {
            return _usrMembershipSocial;
        }
        set
        {
            _usrMembershipSocial = value;
        }
    }

    public string usrMembershipPoliticalText
    {
        get
        {
            return _usrMembershipPoliticalText;
        }
        set
        {
            _usrMembershipPoliticalText = value;
        }
    }

    public string usrMembershipSocialText
    {
        get
        {
            return _usrmembershipSocialText;
        }
        set
        {
            _usrmembershipSocialText = value;
        }
    }

    public int usrActive
    {
        get
        {
            return _usrActive;
        }
        set
        {
            _usrActive = value;
        }
    }

    public int usrLogged
    {
        get
        {
            return _usrLogged;
        }
        set
        {
            _usrLogged = value;
        }
    }

    public int usrControlMobileNo
    {
        get
        {
            return _usrControlMobileNo;
        }
        set
        {
            _usrControlMobileNo = value;
        }
    }

    public string tmpProfilePhoto
    {
        get
        {
            return _tmpProfilePhoto;
        }
        set
        {
            _tmpProfilePhoto = value;
        }
    }

    public string usrProfilePhoto
    {
        get
        {
            return _usrProfilePhoto;
        }
        set
        {
            _usrProfilePhoto = value;
        }
    }

    public int usrTermCond
    {
        get
        {
            return _usrTermCond;
        }
        set
        {
            _usrTermCond = value;
        }
    }

    public string usrRecentVisitor
    {
        get
        {
            return _usrRecentVisitor;
        }
        set
        {
            _usrRecentVisitor = value;
        }

    }

    public string usrRecentVisitor1
    {
        get
        {
            return _usrRecentVisitor1;
        }
        set
        {
            _usrRecentVisitor1 = value;
        }

    }
    public string usrRecentVisitorName
    {
        get
        {
            return _usrRecentVisitorName;
        }
        set
        {
            _usrRecentVisitorName = value;
        }
    }

    public string frnrelUserId
    {
        get
        {
            return _frnrelUserId;
        }
        set
        {
            _frnrelUserId = value;
        }
    }

    public string frnrelFriendId
    {
        get
        {
            return _frnrelFriendId;
        }
        set
        {
            _frnrelFriendId = value;
        }
    }

    public string frnrelFrnRelName
    {
        get
        {
            return _frnrelFrnRelName;
        }
        set
        {
            _frnrelFrnRelName = value;
        }
    }

    public string frnrelRelation
    {
        get
        {
            return _frnrelRelation;
        }
        set
        {
            _frnrelRelation = value;
        }
    }

    public string frnrelSendMsg
    {
        get
        {
            return _frnrelSendMsg;
        }
        set
        {
            _frnrelSendMsg = value;
        }
    }

    public string frnrelGroup
    {
        get
        {
            return _frnrelGroup;
        }
        set
        {
            _frnrelGroup = value;
        }
    }

    public string OfficeNo
    {
        get
        {
            return _OfficeNo;
        }
        set
        {
            _OfficeNo = value;
        }
    }

    public string FaxNo
    {
        get
        {
            return _FaxNo;
        }
        set
        {
            _FaxNo = value;
        }
    }
    public string Website
    {
        get
        {
            return _Website;
        }
        set
        {
            _Website = value;
        }
    }

    private int  _usrAge;

    public int UsrAge
    {
        get { return _usrAge; }
        set { _usrAge = value; }
    }
    private string _usrDesignation;

    public string UsrDesignation
    {
        get { return _usrDesignation; }
        set { _usrDesignation = value; }
    }
    private string strDevId;

    public string StrDevId
    {
        get { return _strDevId; }
        set { _strDevId = value; }
     }
    public List<UserRegistrationBLL> getAllUser
    {
        get
        {
            return _getAllUser;
        }
        set
        {
            _getAllUser = value;
        }
    }

  
  

    
   
   
    public int BLLInsertUserRegistrationInitial(UserRegistrationBLL ur)
    {
        status = urUserRegDALObj.DALInsertUserRegistrationInitial(ur);
        return status;
    }

  

    

    public int BLLIsExistUserRegistrationInitial(UserRegistrationBLL ur)
    {
        status = urUserRegDALObj.DALIsExistUser(ur);
        return status;
    }

   
    
}
