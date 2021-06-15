namespace BGSBDAlcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        AccountNo = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        NominationDetails = c.String(),
                        OpenDate = c.DateTime(),
                        Balance = c.Int(),
                    })
                .PrimaryKey(t => t.AccountNo)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.AtmCumDebitCards",
                c => new
                    {
                        DebitCardNo = c.Long(nullable: false, identity: true),
                        AccountNo = c.Long(nullable: false),
                        PIN = c.Int(nullable: false),
                        Status = c.String(),
                        CVV = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.DebitCardNo)
                .ForeignKey("dbo.AccountDetails", t => t.AccountNo, cascadeDelete: true)
                .Index(t => t.AccountNo);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                        UserID = c.String(),
                        Password = c.String(),
                        TransactionPassword = c.String(),
                        AadharID = c.String(),
                        PanID = c.String(),
                        KYCStatus = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                        LastLogOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.ServiceRequestNoes",
                c => new
                    {
                        ServiceRequestId = c.Int(nullable: false, identity: true),
                        AccountNo = c.Long(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        DateOfCompletion = c.DateTime(nullable: false),
                        ServiceType = c.String(),
                        ServiceRequestStatus = c.String(),
                    })
                .PrimaryKey(t => t.ServiceRequestId)
                .ForeignKey("dbo.AccountDetails", t => t.AccountNo, cascadeDelete: true)
                .Index(t => t.AccountNo);
            
            CreateTable(
                "dbo.ServicesSubscribeds",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        AccountNo = c.Long(nullable: false),
                        SubscriptionName = c.String(),
                        SubscriptionDescription = c.String(),
                        SubscriptionStartDate = c.DateTime(nullable: false),
                        SubscriptionEndDate = c.DateTime(nullable: false),
                        SubscriptionAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.AccountDetails", t => t.AccountNo, cascadeDelete: true)
                .Index(t => t.AccountNo);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        AccountNo = c.Long(nullable: false),
                        TransactionAmount = c.Int(nullable: false),
                        TransactionType = c.String(),
                        TransactionMode = c.String(),
                        BeneficiaryID = c.Int(nullable: false),
                        TransactionStatus = c.String(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.AccountDetails", t => t.AccountNo, cascadeDelete: true)
                .ForeignKey("dbo.Beneficiaries", t => t.BeneficiaryID, cascadeDelete: true)
                .Index(t => t.AccountNo)
                .Index(t => t.BeneficiaryID);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        BeneficiaryID = c.Int(nullable: false, identity: true),
                        AccountNo = c.Long(nullable: false),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        Email = c.String(),
                        BankName = c.String(),
                        BankIFSC = c.String(),
                        ConfirmationStatus = c.String(),
                        BeneficiaryType = c.String(),
                    })
                .PrimaryKey(t => t.BeneficiaryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "BeneficiaryID", "dbo.Beneficiaries");
            DropForeignKey("dbo.Transactions", "AccountNo", "dbo.AccountDetails");
            DropForeignKey("dbo.ServicesSubscribeds", "AccountNo", "dbo.AccountDetails");
            DropForeignKey("dbo.ServiceRequestNoes", "AccountNo", "dbo.AccountDetails");
            DropForeignKey("dbo.AccountDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AtmCumDebitCards", "AccountNo", "dbo.AccountDetails");
            DropIndex("dbo.Transactions", new[] { "BeneficiaryID" });
            DropIndex("dbo.Transactions", new[] { "AccountNo" });
            DropIndex("dbo.ServicesSubscribeds", new[] { "AccountNo" });
            DropIndex("dbo.ServiceRequestNoes", new[] { "AccountNo" });
            DropIndex("dbo.AtmCumDebitCards", new[] { "AccountNo" });
            DropIndex("dbo.AccountDetails", new[] { "CustomerID" });
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.Transactions");
            DropTable("dbo.ServicesSubscribeds");
            DropTable("dbo.ServiceRequestNoes");
            DropTable("dbo.Customers");
            DropTable("dbo.AtmCumDebitCards");
            DropTable("dbo.AccountDetails");
        }
    }
}
