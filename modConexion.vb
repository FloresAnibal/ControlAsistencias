Public Module modConexion
    ' Este MÓDULO contiene la cadena de conexión necesaria para trabajar con la base de datos. Se lo utiliza en este lugar
    ' para escribirlo una sola vez y luego se lo llama en donde sea necesario sin tener que volver a escribir toda la ruta
    ' del archivo.
    ' El nivel de acceso se define en PUBLIC para que pueda ser llamado desde cualquier parte del proyecto.

    Public Const cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source= C:\Users\Aníbal\Desktop\ControlAsistencias-Dic2024\Base de Datos\BaseDatosAsistencias.accdb"
End Module
