using System;
using System.Collections.Generic;
using System.Text;

namespace LCSS.Model
{
    [Serializable]
    public class LoginInfo
    {
        public string _LoginID;
        public string _UserID;
        public string _UserName;
        public string _OrgCode;
        public string _OrgName;
        public string _UserRole;
        public string _LoginType;
        public string _TradeType;
        public string _Agent;
        public string _IPAdr;
        public string _HostName;
        public string _LoginTime;

        /// <summary>
        /// ��¼�˺�
        /// </summary>
        public string LoginID
        {
            get { return _LoginID; }
            set { _LoginID = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// ������ҵ����
        /// </summary>
        public string OrgCode
        {
            get { return _OrgCode; }
            set { _OrgCode = value; }
        }
        /// <summary>
        /// ������ҵ����
        /// </summary>
        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
        /// <summary>
        /// �û���ɫ��web.config key=UserRoles��
        /// </summary>
        public string UserRole
        {
            get { return _UserRole; }
            set { _UserRole = value; }
        }
        /// <summary>
        /// �ͻ��˲���ϵͳ����Ϣ
        /// </summary>
        public string Agent
        {
            get { return _Agent; }
            set { _Agent = value; }
        }
        /// <summary>
        /// IP��ַ
        /// </summary>
        public string IPAdr
        {
            get { return _IPAdr; }
            set { _IPAdr = value; }
        }
        /// <summary>
        /// �ͻ���DNS��
        /// </summary>
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public string LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
        }
    }
    
}