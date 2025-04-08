using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Learning.AppCode
{
    public class Cls
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConDEV"].ConnectionString);
        public SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSTR"].ConnectionString);

        // Method to open connection
        public SqlConnection OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                if (con.ConnectionString == "")
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConDEV"].ConnectionString);
                    con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSTR"].ConnectionString);
                }
                con.Open();
            }
            else
            {
                con.Close();
            }
            return con;
        }

        // Method to close connection
        public SqlConnection CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
            return con;
        }

        // Method to insert form data into database
        public bool InsertVoucherData(string phone, string customerName, string location, string billNo, decimal vouAmount, string voucher)
        {
            try
            {
                // SQL query to insert data into database mobileno,cusarea,customername,vouno
                string query = @"INSERT INTO dbo.othergiftvoucher
                                           (voudate
                                           , vouno
                                           , amount
                                           , voucustomername
                                           , voumobileno
                                           , voucompany
                                           , cusarea
                                           , status
                                           , customername
                                           , mobileno
                                           , vouissdate
                                           , adjtranno
                                           , adjdate
                                           , adjcompany
                                           , createddate
                                           , createdtime
                                           , Datatranflag
                                           , adjdatetime)
                                     VALUES
                                           (getdate()
                                           , @Voucher
                                           , @VouAmount
                                           , @CustomerName
                                           , @Phone
                                           , '17'
                                           , @Location
                                           , 1
                                           , ''
                                           , ''
                                           , getdate()
                                           , 0
                                           , '1900-01-01'
                                           , ''
                                           , '2024-11-19'
                                           , '2024-11-19 00:00:00.000'
                                           , 'Y'
                                           , NULL);
                                                ";

                // Open connection
                SqlConnection con = OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the SQL query
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@BillNo", billNo);
                    cmd.Parameters.AddWithValue("@VouAmount", vouAmount);
                    cmd.Parameters.AddWithValue("@Voucher", voucher);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // If at least one row was inserted, return true
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (e.g., log to a file or database)
                throw new Exception("Error in InsertVoucherData: " + ex.Message);
            }
            finally
            {
                // Close connection in case of success or failure
                CloseConnection();
            }
        }

        public DataSet ModalprintDetails(string qcNum)
        {

            string qry = "";
            DataSet datas = new DataSet();

            try
            {
                qry = "SELECT qc_no, vendername,product,subproduct,weight,selectedweight,remarks,checkedDate,checkedby FROM QC WHERE qc_no = '" + qcNum + "' or vendername = '" + qcNum + "'";
                SqlCommand cmd = new SqlCommand(qry, con1);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                sda.Fill(datas);
                return datas;

            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }


        // qc Main Test
        public DataSet printDetails(string qcNum)
        {

            string qry = "";
            DataSet datas = new DataSet();

            try
            {
                qry = "SELECT qc_no, vendername,product,subproduct,weight,selectedweight,remarks,checkedDate,checkedby FROM QC WHERE qc_no = '" + qcNum + "' or vendername = '" + qcNum + "'";
                SqlCommand cmd = new SqlCommand(qry, con1);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                sda.Fill(datas);
                return datas;

            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public DataSet QcAutoFill(string qcNum) {
        DataSet datas = new DataSet();
            return datas;
        }

        public DataSet QcVendorAutoFill(string vendor)
        {
            DataSet datas = new DataSet();
            return datas;
        }

        public void DetailsCheck(string qcNum, string vname, string pro, string subPro, decimal weight, decimal selectedWeight, string remarks, string submitby, string submitid, string submitbrh, string submitbrhid)
        {
            return;
        }

        public void DetailsAdd(string vname, string vcode, string pro, string subPro, string subPro2, string subPro3, string subPro4, string subPro5, decimal weight, string remarks, string submitby, string submitid, string submitbrh, string submitbrhid)
        {
            return;
        }
        public string getQcNum()
        {
            string s ="hello";
            return s;
        }


    }
}