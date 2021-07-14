using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceContract]
    public interface IBank
    {
        [OperationContract]
        void SaveToDisk();

        [OperationContract]
        void ProcessAllTransactions();

        //Account methods
        [OperationContract]
        void SelectAccount(uint accID);

        [OperationContract]
        List<uint> GetAccountIDsByUser(uint userID);

        [OperationContract]
        uint CreateAccount(uint userID);

        [OperationContract]
        Boolean Deposit(uint amount);

        [OperationContract]
        Boolean Withdraw(uint amount);

        [OperationContract]
        uint GetBalance();

        [OperationContract]
        uint GetOwner();

        //User methods
        [OperationContract]
        void SelectUser(uint userID);

        [OperationContract]
        List<uint> GetUsers();

        [OperationContract]
        uint CreateUser();

        [OperationContract]
        void GetUserName(out string fname, out string lname);

        [OperationContract]
        void SetUserName(string fname, string lname);

        [OperationContract]
        uint Register(uint id , string uname, string pwd);

        [OperationContract]
        uint Login(string uname, string pwd);

        //Transaction methods
        [OperationContract]
        void SelectTransaction(uint transID);

        [OperationContract]
        List<uint> GetTransactions();

        [OperationContract]
        uint CreateTransaction();

        [OperationContract]
        uint GetAmount();

        [OperationContract]
        uint GetSendrAcct();

        [OperationContract]
        uint GetRecvrAcct();

        [OperationContract]
        void SetAmount(uint amount);

        [OperationContract]
        void SetSendr(uint accID);

        [OperationContract]
        void SetRecvr(uint accID);

    }
}
