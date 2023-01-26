using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class DALEntrada
{
    public Boolean insertarEntrada(EntidadEntrada entrada)
    {

        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();


        cmd.Parameters.Add(new SqlParameter("@Museo_id", entrada.Museo_id));
        cmd.Parameters.Add(new SqlParameter("@Precio_id", entrada.Precio_id));
        cmd.Parameters.Add(new SqlParameter("@Tarjeta_id", entrada.Tarjeta_id));
        cmd.Parameters.Add(new SqlParameter("@Entrada_nombreVisitante", entrada.Entrada_nombreVisitante));
        cmd.Parameters.Add(new SqlParameter("@Entrada_fecha", entrada.Entrada_fecha));
        cmd.Parameters.Add(new SqlParameter("@Entrada_cantidad", entrada.Entrada_cantidad));
        cmd.Parameters.Add(new SqlParameter("@Entrada_subtotal", entrada.Entrada_subtotal));
        cmd.Parameters.Add(new SqlParameter("@Entrada_comision", entrada.Entrada_comision));
        cmd.Parameters.Add(new SqlParameter("@Entrada_total", entrada.Entrada_total));
        cmd.Parameters.Add(new SqlParameter("@Entrada_estado", entrada.Entrada_estado));

        cmd.CommandText = "InsertarEntrada";
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
    public List<EntidadEntrada> listarEntrada()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarEntrada";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadEntrada> lista = new List<EntidadEntrada>();

        while (dr.Read())
        {
            EntidadEntrada entrada = new EntidadEntrada();

            entrada.Entrada_id = int.Parse(dr["Entrada_id"].ToString());
            entrada.Museo_id = int.Parse(dr["Museo_id"].ToString());
            entrada.Precio_id = int.Parse(dr["Precio_id"].ToString());
            entrada.Tarjeta_id = int.Parse(dr["Tarjeta_id"].ToString());
            entrada.Entrada_nombreVisitante = dr["Entrada_nombreVisitante"].ToString();
            entrada.Entrada_fecha = Convert.ToDateTime( dr["Entrada_fecha"].ToString());
            entrada.Entrada_cantidad = dr["Entrada_cantidad"].ToString();
            entrada.Entrada_subtotal = dr["Entrada_subtotal"].ToString();
            entrada.Entrada_comision = dr["Entrada_comision"].ToString();
            entrada.Entrada_total = dr["Entrada_total"].ToString();
            entrada.Entrada_estado = dr["Entrada_estado"].ToString();

            lista.Add(entrada);
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
