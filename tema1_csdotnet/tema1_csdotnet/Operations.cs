using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace tema1_csdotnet
{
    class Operations
    {
        public string connection_string;

        public Operations()
        {
        }

        public void InsertCustomer(string name, string adresa)
        {
            using (var db = new TestContext())
            {
                db.Connection.Open();
                using(var dbContextTransaction = db.Connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "Insert into CUSTOMER (Name, Adresa) VALUES (@pName, @pAdresa)";
                        var args = new DbParameter[] { new SqlParameter { ParameterName = "pName", Value = name }, new SqlParameter { ParameterName = "pAdresa", Value = adresa } };
                        db.ExecuteStoreCommand(sql, args);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void InsertOrder(DateTime data, int customerid, int valoare)
        {
            using (var db = new TestContext())
            {
                db.Connection.Open();
                using (var dbContextTransaction = db.Connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "Insert into ORDER (DATA, CUSTOMERID, VALOARE) VALUES (@pData, @pCustomerID, @pValoare)";
                        var args = new DbParameter[] { new SqlParameter { ParameterName = "pData", Value = data }, new SqlParameter { ParameterName = "pCustomerID", Value = customerid },
                                                        new SqlParameter{ParameterName = "pValoare", Value = valoare}};
                        db.ExecuteStoreCommand(sql, args);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void InsertOrderDetail(int orderid, string produs, int valoare, int serial)
        {
            using (var db = new TestContext())
            {
                db.Connection.Open();
                using (var dbContextTransaction = db.Connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "Insert into ORDERDETAILS (ORDERID, PRODUS, VALOARE, SERIAL) VALUES (@pOrderID, @pProdus, @pValoare, @pSerial)";
                        var args = new DbParameter[] { new SqlParameter{ParameterName = "pOrderID", Value = orderid},new SqlParameter { ParameterName = "pProdus", Value = produs }, new SqlParameter { ParameterName = "pValoare", Value = valoare },
                                                        new SqlParameter{ParameterName = "pSerial", Value = serial}};
                        db.ExecuteStoreCommand(sql, args);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void UpdateCustomer(string name, string adresa)
        {
            using(var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "UPDATE CUSTOMER SET ADRESA=@pAdresa WHERE NAME=@pName";
                            var args = new DbParameter[] { new SqlParameter { ParameterName = "pName", Value = name }, new SqlParameter { ParameterName = "pAdresa", Value = adresa } };
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }

        public void UpdateOrder(DateTime data, int customerid, int valoare)
        {
            using (var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "UPDATE ORDER SET DATA=@pData, VALOARE=@pValoare WHERE CUSTOMERID=@pCustomerID";
                            var args = new DbParameter[] { new SqlParameter { ParameterName = "pData", Value = data }, new SqlParameter { ParameterName = "pCustomerID", Value = customerid },
                                                        new SqlParameter{ParameterName = "pValoare", Value = valoare}};
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }


        public void UpdateOrderDetails(int orderid, string produs, int valoare, int serial)
        {
            using (var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "UPDATE ORDERDETAILS SET PRODUS=@pProdus, VALOARE=@pValoare, SERIAL=@pSERIAL WHERE CUSTOMERID=@pCustomerID";
                            var args = new DbParameter[] { new SqlParameter{ParameterName = "pOrderID", Value = orderid},new SqlParameter { ParameterName = "pProdus", Value = produs }, new SqlParameter { ParameterName = "pValoare", Value = valoare },
                                                        new SqlParameter{ParameterName = "pSerial", Value = serial}};
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }

        public void DeleteCustomer(string name)
        {
            using (var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "DELETE CUSTOMER WHERE NAME=@pName";
                            var args = new DbParameter[] { new SqlParameter{ParameterName = "pName", Value = name}};
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }

        public void DeleteOrder(int customerid)
        {
            using (var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "DELETE ORDER WHERE CUSTOMERID=@pCustomerID";
                            var args = new DbParameter[] { new SqlParameter { ParameterName = "pCustomerID", Value = customerid } };
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }

        public void DeleteOrder(int orderid, string produs)
        {
            using (var scope = new TransactionScope())
            {
                using (var db = new TestContext())
                {
                    db.Connection.Open();
                    using (var dbContextTransaction = db.Connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "DELETE ORDERDETAILS WHERE ORDERID=@pOrderID AND PRODUS=@pProdus";
                            var args = new DbParameter[] { new SqlParameter { ParameterName = "pOrderID", Value =orderid },
                                                            new SqlParameter{ParameterName="pProdus", Value = produs}};
                            db.ExecuteStoreCommand(sql, args);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
                scope.Complete();
            }
        }

    }
}
