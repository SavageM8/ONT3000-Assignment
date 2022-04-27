using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    internal class SupplierDBAccess
    {

        public List<Suppliers> GetSuppliersList()
        {
            List<Suppliers> suppliersList = null;

            using (DataTable table = DBHelper.ExecuteSelectCommand("SpGetAllSuppliers",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    suppliersList = new List<Suppliers>();
                    foreach (DataRow row in table.Rows)
                    {
                        Suppliers supplier = new Suppliers();
                        supplier.SupplierID = Convert.ToInt32(row["SupplierID"]);
                        supplier.CompanyName = row["CompanyName"].ToString();
                        supplier.ContactTitle = row["ContactTitle"].ToString();
                        supplier.Address = row["Address"].ToString();
                        supplier.City = row["City"].ToString();
                        supplier.Region = row["Region"].ToString();
                        supplier.PostalCode = row["PostalCode"].ToString();
                        supplier.Country = row["Country"].ToString();
                        supplier.Phone = row["Phone"].ToString();
                        supplier.Fax = row["Fax"].ToString();
                        supplier.HomePage = row["Homepage"].ToString();
                        suppliersList.Add(supplier);
                    }
                }//end if
            }//end using
            return suppliersList;
        }//End GetSupplierDetails

        public Suppliers GetSuppliersByID(int suppliersID)
        {
            Suppliers supplier = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SuppliersID", suppliersID)
            };
            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("SpGetSupplierByID",
                CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    supplier = new Suppliers();
                    supplier.SupplierID = Convert.ToInt32(row["SupplierID"]);
                    supplier.CompanyName = row["CompanyName"].ToString();
                    supplier.ContactTitle = row["ContactTitle"].ToString();
                    supplier.Address = row["Address"].ToString();
                    supplier.City = row["City"].ToString();
                    supplier.Region = row["Region"].ToString();
                    supplier.PostalCode = row["PostalCode"].ToString();
                    supplier.Country = row["Country"].ToString();
                    supplier.Phone = row["Phone"].ToString();
                    supplier.Fax = row["Fax"].ToString();
                    supplier.HomePage = row["Homepage"].ToString();

                }//end if
            }//end using
            return supplier;
        }//End GetSuppliersByID

        public bool DeleteSuppliersByID(int supplierID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SupplierID", supplierID)
            };
            return DBHelper.ExecuteNonQuery("SpDeleteSupplierByID", CommandType.StoredProcedure,
                parameters);
        }//End DeleteSuppliersByID

        public bool InsertSuppliers(Suppliers supplier)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SupplierID", supplier.SupplierID),
                new SqlParameter("@CompanyName", supplier.CompanyName),
                new SqlParameter("@ContactTitle", supplier.ContactTitle),
                new SqlParameter("@Address", supplier.Address),
                new SqlParameter("@City", supplier.City),
                new SqlParameter("@Region", supplier.Region),
                new SqlParameter("@PostalCode",supplier.PostalCode),
                new SqlParameter("@Country",supplier.Country),
                new SqlParameter("@Phone",supplier.Phone),
                new SqlParameter("@Fax",supplier.Fax),
                new SqlParameter("@Homepage",supplier.HomePage)

            };
            return DBHelper.ExecuteNonQuery("SpInsertSuppliers", CommandType.StoredProcedure,
                parameters);
        }//End InsertSuppliers

        public bool UpdateSuppliers(Suppliers supplier)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyName", supplier.CompanyName),
                new SqlParameter("@ContactTitle", supplier.ContactTitle),
                new SqlParameter("@Address", supplier.Address),
                new SqlParameter("@City", supplier.City),
                new SqlParameter("@Region", supplier.Region),
                new SqlParameter("@PostalCode",supplier.PostalCode),
                new SqlParameter("@Country",supplier.Country),
                new SqlParameter("@Phone",supplier.Phone),
                new SqlParameter("@Fax",supplier.Fax),
                new SqlParameter("@Homepage",supplier.HomePage)
            };
            return DBHelper.ExecuteNonQuery("SpUpdateSupplier", CommandType.StoredProcedure,
                parameters);
        }//End UpdateSuppliers


    }
}
