using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DALMuseo
{

    public Boolean insertarMuseo(EntidadMuseo museo)
    {

        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();


        cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", museo.TipoMuseo_id));
        cmd.Parameters.Add(new SqlParameter("@Museo_nombre", museo.Museo_nombre));
        cmd.Parameters.Add(new SqlParameter("@Museo_instalacion", museo.Museo_instalacion));
        cmd.Parameters.Add(new SqlParameter("@Museo_estado", museo.Museo_estado));

        cmd.CommandText = "InsertarMuseo";
        cmd.CommandType = CommandType.StoredProcedure;
    
    int x = cmd.ExecuteNonQuery();
    aux.conectar();

        if (x >= 1)
        {
            return true;
        }
        else
            return false;
     }
    public List<EntidadMuseo> listarMuseo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarMuseo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadMuseo> lista = new List<EntidadMuseo>();

        while (dr.Read())
        {
            EntidadMuseo museo = new EntidadMuseo();

            museo.Museo_id = int.Parse(dr["Museo_id"].ToString());
            museo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
            museo.Museo_nombre = dr["Museo_nombre"].ToString();
            museo.Museo_instalacion = dr["Museo_instalacion"].ToString();
            museo.Museo_estado = dr["Museo_estado"].ToString();

            lista.Add(museo);
        }
        aux.conectar();

        return lista;
    }

    public List<EntidadMuseo> listarInactivo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarMuseoInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadMuseo> lista = new List<EntidadMuseo>();

        while (dr.Read())
        {
            EntidadMuseo museo = new EntidadMuseo();

            museo.Museo_id = int.Parse(dr["Museo_id"].ToString());
            museo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
            museo.Museo_nombre = dr["Museo_nombre"].ToString();
            museo.Museo_instalacion = dr["Museo_instalacion"].ToString();
            museo.Museo_estado = dr["Museo_estado"].ToString();

            lista.Add(museo);
        }
        aux.conectar();

        return lista;
    }

    public void modificarMuseo(EntidadMuseo museo)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Museo_id", museo.Museo_id));
        cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", museo.TipoMuseo_id));
        cmd.Parameters.Add(new SqlParameter("@Museo_nombre", museo.Museo_nombre));
        cmd.Parameters.Add(new SqlParameter("@Museo_instalacion", museo.Museo_instalacion));
        cmd.Parameters.Add(new SqlParameter("@Museo_estado", museo.Museo_estado));

        cmd.CommandText = "ModificarMuseo";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        aux.conectar();
    }

    public Boolean eliminarMuseo(int Museo_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Museo_id", Museo_id));

        cmd.CommandText = "InactivarMuseo";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public Boolean activarMuseo(int Museo_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Museo_id", Museo_id));

        cmd.CommandText = "ActivarMuseo";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public EntidadMuseo buscarMuseo(int Museo_id)
    {
        EntidadMuseo museo = new EntidadMuseo();
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Museo_id", museo.Museo_id));

        cmd.CommandText = "ConsultarMuseo";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            museo.Museo_id = int.Parse(dr["Museo_id"].ToString());
            museo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
            museo.Museo_nombre = dr["Museo_nombre"].ToString();
            museo.Museo_instalacion = dr["Museo_instalacion"].ToString();
            museo.Museo_estado = dr["Museo_estado"].ToString();
        }
        else
        {
            museo = null;
        }
        aux.conectar();

        return museo;
    }
    
}