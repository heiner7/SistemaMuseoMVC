using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Conectividad
    {
    string strConn;

    public SqlConnection conectar()
    {
        try
        {
            strConn = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString.ToString();
        }
        catch (Exception ex)
        {
            strConn = @"Data Source= DESKTOP-MAQMOR9\SQLEXPRESS;Initial Catalog=SistemaMuseo; " +
                "Integrated Security = True";
        }
        SqlConnection conn = new SqlConnection(strConn);

        try
        {
            if (conn.State.Equals(ConnectionState.Closed))
                conn.Open();
            else
                conn.Close();
        }
        catch (Exception ex)
        { }

        return conn;
    }
}
