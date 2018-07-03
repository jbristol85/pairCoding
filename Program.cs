﻿using System;
using System.Collections.Generic;

namespace pairCoding
{
    class program
    {

        public class Transaction
        {
            public string type { get; set; }
            public static DateTime Now { get; }
            public double amount { get; set; }

            public Transaction(int _amount, string _type)
            {
                this.amount = _amount;
                this.type = _type;
            }
        }

        abstract class BankAccount
        {
            public string accountHolderName { get; set; }
            public int accountBalance { get; set; }

            public int accountNumber { get; set; }

            public DateTime openedOn { get; set; }

            public List<Transaction> Transactions = new List<Transaction>();

            public void ApplyTransaction(Transaction transaction)
            {
                //add to queue
                Transaction.Add(transaction);
            }

            public RemoveTransaction()
            {
                var firstTransaction = transaction[0];
                transaction.RemoveAt(0);
                return firstTransaction;
            }
        }

        class SavingsAccount : BankAccount
        {

            public int InterestRate { get; set; }

            public SavingsAccount()
            {

            }

            public SavingsAccount(string _accountHolderName, int _balance, int _interestRate)
            {
                this.accountHolderName = _accountHolderName;
                this.accountBalance = _balance;
                this.InterestRate = _interestRate;
            }

            public void AddInterest()
            {
                var amount = accountBalance * InterestRate;
                var type = "Add Interest";
                this.accountBalance += amount;
                var addInterest = new Transaction(amount, type);
                ApplyTransaction(addInterest);
            }
        }

        class CheckingAccount : BankAccount
        {

            public int ServiceFee { get; set; }

            public CheckingAccount()
            {

            }

            public CheckingAccount(string _accountHolderName, int _balance, int _serviceFee)
            {
                this.accountHolderName = _accountHolderName;
                this.accountBalance = _balance;
                this.ServiceFee = _serviceFee;
            }

            public void AddServiceFee()
            {
                var amount = this.ServiceFee;
                var type = "Service Fee";
                this.accountBalance -= amount;
                var addSerivceFee = new Transaction(amount, type);
            }




        }


        class Program
        {
            static void Main(string[] args)
            {
                var SavingsAccount1 = new SavingsAccount()
                {
                    accountHolderName = "Josh",
                    accountNumber = "654321",
                    accountBalance = 2000,
                    InterestRate = .023,
                    openedOn = DateTime.Now,
                    
                };

                var CheckingAccount1 = new CheckingAccount()
                {
                    accountHolderName = "Jim",
                    accountNumber = "123456",
                    accountBalance = 1000,
                    InterestRate = .025,
                    openedOn = DateTime.Now,
                };

                var tranaction1 = new Transaction()
                {
                    type = "checking",
                    ServiceFee = 10
                };
                
            }
        }
    }
}
