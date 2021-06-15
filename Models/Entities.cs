using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BGSBcodefirst.Models
{
    public class Entities
    {

    }

    public class AccountDetail {
        [Key]
        public long AccountNo { get; set; }
        public long CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public System.DateTime DOB { get; set; }
        public string NominationDetails { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<int> Balance { get; set; }

        public virtual Customer Customer { get; set; }
       
        public virtual ICollection<AtmCumDebitCard> AtmCumDebitCard { get; set; }
       
        public virtual ICollection<ServiceRequestNo> ServiceRequestNo { get; set; }
       
        public virtual ICollection<ServicesSubscribed> ServicesSubscribed { get; set; }
       
        public virtual ICollection<Transaction> Transaction { get; set; }

    }


    public class AtmCumDebitCard {
        [Key]
        public long DebitCardNo { get; set; }
        public long AccountNo { get; set; }
        public int PIN { get; set; }
        public string Status { get; set; }
        public int CVV { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public string DisplayName { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }
    }



    public class Beneficiary {
        [Key]
        public int BeneficiaryID { get; set; }
        public long AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string BankName { get; set; }
        public string BankIFSC { get; set; }
        public string ConfirmationStatus { get; set; }
        public string BeneficiaryType { get; set; }

       
        public virtual ICollection<Transaction> Transaction { get; set; }
    }



    public class Customer {
        [Key]
        public long CustomerID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string TransactionPassword { get; set; }
        public string AadharID { get; set; }
        public string PanID { get; set; }
        public string KYCStatus { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastLogOut { get; set; }
        public virtual ICollection<AccountDetail> AccountDetail { get; set; }
    }



    public class Transaction {
        [Key]
        public int TransactionID { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public long AccountNo { get; set; }
        public int TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMode { get; set; }
        public int BeneficiaryID { get; set; }
        public string TransactionStatus { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }
        public virtual Beneficiary Beneficiary { get; set; }
    }

    public class ServiceRequestNo {
        [Key]
        public int ServiceRequestId { get; set; }
        public long AccountNo { get; set; }
        public System.DateTime DateOfRequest { get; set; }
        public System.DateTime DateOfCompletion { get; set; }
        public string ServiceType { get; set; }
        public string ServiceRequestStatus { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }
    }

    public class ServicesSubscribed {
        [Key]
        public int ServiceID { get; set; }
        public long AccountNo { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionDescription { get; set; }
        public System.DateTime SubscriptionStartDate { get; set; }
        public System.DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionAmount { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }
    }
}