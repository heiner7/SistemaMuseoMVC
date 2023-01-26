using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DALObra
{

    public Boolean insertarObra(EntidadObra obra)
    {

        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();


        cmd.Parameters.Add(new SqlParameter("@Artista_id", obra.Artista_id));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", obra.Coleccion_id));
        cmd.Parameters.Add(new SqlParameter("@TipoObra_id", obra.TipoObra_id));
        cmd.Parameters.Add(new SqlParameter("@Obra_nombre", obra.Obra_nombre));
        cmd.Parameters.Add(new SqlParameter("@Obra_descripcion", obra.Obra_descripcion));
        cmd.Parameters.Add(new SqlParameter("@Obra_cultura", obra.Obra_cultura));
        cmd.Parameters.Add(new SqlParameter("@Obra_estado", obra.Obra_estado));

        cmd.CommandText = "InsertarObra";
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
    public List<EntidadObra> listarObra()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarObra";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadObra> lista = new List<EntidadObra>();

        while (dr.Read())
        {
            EntidadObra obra = new EntidadObra();

            obra.Obra_id = int.Parse(dr["Obra_id"].ToString());
            obra.Artista_id = int.Parse(dr["Artista_id"].ToString());
            obra.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            obra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
            obra.Obra_nombre = dr["Obra_nombre"].ToString();
            obra.Obra_descripcion = dr["Obra_descripcion"].ToString();
            obra.Obra_cultura = dr["Obra_cultura"].ToString();
            obra.Obra_estado = dr["Obra_estado"].ToString();

            lista.Add(obra);
        }
        aux.conectar();

        return lista;
    }

    public List<EntidadObra> listarInactivo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarObraInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadObra> lista = new List<EntidadObra>();

        while (dr.Read())
        {
            EntidadObra obra = new EntidadObra();

            obra.Obra_id = int.Parse(dr["Obra_id"].ToString());
            obra.Artista_id = int.Parse(dr["Artista_id"].ToString());
            obra.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            obra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
            obra.Obra_nombre = dr["Obra_nombre"].ToString();
            obra.Obra_descripcion = dr["Obra_descripcion"].ToString();
            obra.Obra_cultura = dr["Obra_cultura"].ToString();
            obra.Obra_estado = dr["Obra_estado"].ToString();

            lista.Add(obra);
        }
        aux.conectar();

        return lista;
    }

    public void modificarObra(EntidadObra obra)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Obra_id", obra.Obra_id));
        cmd.Parameters.Add(new SqlParameter("@Artista_id", obra.Artista_id));
        cmd.Parameters.Add(new SqlParameter("@Coleccion_id", obra.Coleccion_id));
        cmd.Parameters.Add(new SqlParameter("@TipoObra_id", obra.TipoObra_id));
        cmd.Parameters.Add(new SqlParameter("@Obra_nombre", obra.Obra_nombre));
        cmd.Parameters.Add(new SqlParameter("@Obra_descripcion", obra.Obra_descripcion));
        cmd.Parameters.Add(new SqlParameter("@Obra_cultura", obra.Obra_cultura));
        cmd.Parameters.Add(new SqlParameter("@Obra_estado", obra.Obra_estado));

        cmd.CommandText = "ModificarObra";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        aux.conectar();
    }

    public Boolean eliminarObra(int Obra_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Obra_id", Obra_id));

        cmd.CommandText = "InactivarObra";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public Boolean activarObra(int Obra_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Obra_id", Obra_id));

        cmd.CommandText = "ActivarObra";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public EntidadObra buscarObra(int obra_id)
    {
        EntidadObra obra = new EntidadObra();
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Obra_id", obra.Obra_id));

        cmd.CommandText = "ConsultarObra";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            obra.Obra_id = int.Parse(dr["Obra_id"].ToString());
            obra.Artista_id = int.Parse(dr["Artista_id"].ToString());
            obra.Coleccion_id = int.Parse(dr["Coleccion_id"].ToString());
            obra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
            obra.Obra_nombre = dr["Obra_nombre"].ToString();
            obra.Obra_descripcion = dr["Obra_descripcion"].ToString();
            obra.Obra_cultura = dr["Obra_cultura"].ToString();
            obra.Obra_estado = dr["Obra_estado"].ToString();
        }
        else
        {
            obra = null;
        }
        aux.conectar();

        return obra;
    }

}
