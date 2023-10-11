Imports System.Data.OleDb

Public Class frmAcceso

    ' Cadena de conexión a la base de datos Access
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source= E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click
        Dim usuario As String = txtBxUsuario.Text
        Dim contraseña As String = txtBxPass.Text
        Dim sqlQuery As String = ""

        ' El valor del radiobutton define el nombre de la tabla que guardo en la variable 
        If rdBtnEstu.Checked = True Then

            ' Consulta SQL para verificar el usuario y la contraseña en la tabla Estudiantes
            sqlQuery = "SELECT COUNT(*) 
                        FROM Estudiantes 
                        WHERE StrComp(dni_estu, @Usuario, 0) = 0 AND StrComp(pass_estu, @Contraseña, 0) = 0"

        ElseIf rdBtnPrece.Checked = True Then

            ' Consulta SQL para verificar el usuario y la contraseña en la tabla Preceptores
            sqlQuery = "SELECT COUNT(*) 
                        FROM Preceptores 
                        WHERE StrComp(dni_prece, @Usuario, 0) = 0 AND StrComp(pass_prece, @Contraseña, 0) = 0"

        End If

        ' Utiliza la estructura Using para asegurar que la conexión se cierre automáticamente
        Using con As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(sqlQuery, con)

                ' Parámetros para evitar la inyección de SQL
                cmd.Parameters.AddWithValue("@Usuario", usuario)
                cmd.Parameters.AddWithValue("@Contraseña", contraseña)

                Try
                    con.Open()

                    ' ExecuteScalar() ejecuta la consulta y devuelve un valor que representa el conteo de registros
                    Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Se verifica si el conteo es mayor que 0. Si es mayor,
                    ' significa que las credenciales son válidas y se muestra el formulario correspondiente
                    If result > 0 Then

                        ' Se oculta el formulario actual
                        Me.Hide()

                        If rdBtnEstu.Checked = True Then
                            ' Se muestra el Formulario correspondiente
                            frmAsistenciaEstudiante.Show()
                        Else
                            ' Se muestra el Formulario correspondiente
                            frmCargaAsis.Show()
                        End If

                    Else
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al iniciar sesión: " & ex.Message)
                End Try

            End Using  ' La conexión se cerrará automáticamente aquí
        End Using
    End Sub

    Private Sub SalirMenuAcceso_Click(sender As Object, e As EventArgs) Handles SalirMenuAcceso.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub
End Class


'StrComp(string1, string2, modoComparacion)
'string1 y String 2 son las cadenas a comparar.
'modoComparacion es cómo se comparan las cadenas, pudiendo ser "Binario" (valor 0) que distingue
'las mayúsculas de minúsculas y "Texto" (valor 1) que no distingue mayúsculas de minúsculas.

'La función devuelve 0 si las cadenas son iguales. Si no lo son, devuelve 1 o -1.