using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DALColeccion
{

    public Boolean insertarColeccion(EntidadColeccion coleccion)
    {

        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();


        cmd.Parameters.Add(new SqlParameter("@Museo_id", coleccion.Museo_id));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_nombre", coleccion.Coleccion_nombre));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_siglo", coleccion.Coleccion_siglo));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_observaciones", coleccion.Coleccion_observaciones));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_estado", coleccion.Coleccion_estado));

        cmd.CommandText = "InsertarColeccion";
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
    public List<EntidadColeccion> listarColeccion()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarColeccion";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadColeccion> lista = new List<EntidadColeccion>();

        while (dr.Read())
        {
            EntidadColeccion coleccion = new EntidadColeccion();

            coleccion.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            coleccion.Museo_id = int.Parse(dr["Museo_id"].ToString());
            coleccion.Coleccion_nombre = dr["Coleccion_nombre"].ToString();
            coleccion.Coleccion_siglo = dr["Coleccion_siglo"].ToString();
            coleccion.Coleccion_observaciones = dr["Coleccion_observaciones"].ToString();
            coleccion.Coleccion_estado = dr["Coleccion_estado"].ToString();

            lista.Add(coleccion);
        }
        aux.conectar();

        return lista;
    }

    public List<EntidadColeccion> listarInactivo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarColeccionInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadColeccion> lista = new List<EntidadColeccion>();

        while (dr.Read())
        {
            EntidadColeccion coleccion = new EntidadColeccion();

            coleccion.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            coleccion.Museo_id = int.Parse(dr["Museo_id"].ToString());
            coleccion.Coleccion_nombre = dr["Coleccion_nombre"].ToString();
            coleccion.Coleccion_siglo = dr["Coleccion_siglo"].ToString();
            coleccion.Coleccion_observaciones = dr["Coleccion_observaciones"].ToString();
            coleccion.Coleccion_estado = dr["Coleccion_estado"].ToString();

            lista.Add(coleccion);
        }
        aux.conectar();

        return lista;
    }

    public void modificarColeccion(EntidadColeccion coleccion)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", coleccion.Coleccion_id));
        cmd.Parameters.Add(new SqlParameter("@Museo_id", coleccion.Museo_id));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_nombre", coleccion.Coleccion_nombre));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_siglo", coleccion.Coleccion_siglo));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_observaciones", coleccion.Coleccion_observaciones));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_estado", coleccion.Coleccion_estado));

        cmd.CommandText = "ModificarColeccion";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        aux.conectar();
    }

    public Boolean eliminarColeccion(int Coleccion_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", Coleccion_id));

        cmd.CommandText = "InactivarColeccion";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public Boolean activarColeccion(int Coleccion_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", Coleccion_id));

        cmd.CommandText = "ActivarColeccion";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public EntidadColeccion buscarColeccion(int Coleccion_id)
    {
        EntidadColeccion coleccion = new EntidadColeccion();
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", coleccion.Coleccion_id));

        cmd.CommandText = "ConsultarColeccion";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            coleccion.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            coleccion.Museo_id = int.Parse(dr["Museo_id"].ToString());
            coleccion.Coleccion_nombre = dr["Coleccion_nombre"].ToString();
            coleccion.Coleccion_siglo = dr["Coleccion_siglo"].ToString();
            coleccion.Coleccion_observaciones = dr["Coleccion_observaciones"].ToString();
            coleccion.Coleccion_estado = dr["Coleccion_estado"].ToString();
        }
        else
        {
            coleccion = null;
        }
        aux.conectar();

        return coleccion;
    }

}
