Imports System.Data.OleDb

Public Class frmAcceso

    ' Array de tipo TextBox
    Dim camposAcceso() As TextBox

    Private Sub frmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Crarga del array con todos los TextBox del formulario. Se usará para validar su contenido
        camposAcceso = {txtBxUsuario, txtBxPass}
    End Sub

    ' Cadena de conexión a la base de datos Access
    Private connectionString As String = modConexion.cadenaConexion

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click

        ' Se valida la entrada de datos llamando a la función correspondiente
        If modValidaciones.camposLlenos(camposAcceso) = True Then

            Dim usuario As String = txtBxUsuario.Text
            Dim contraseña As String = txtBxPass.Text
            Dim sqlQuery As String

            ' El valor del RadioButton define el nombre de la tabla que se guarda en la variable 
            If rdBtnEstu.Checked = True Then

                ' Consulta SQL para verificar el usuario y la contraseña en la tabla Estudiantes
                ' La consulta SQL realiza un conteo de las veces que se cumplen la condición del WHERE
                sqlQuery = "SELECT COUNT(*) 
                            FROM Estudiantes 
                            WHERE dni_estu = @Usuario AND StrComp(pass_estu, @Contraseña, 0) = 0"

            Else    ' Esto significa que el RadioButton seleccionado es el de Preceptores

                ' Consulta SQL para verificar el usuario y la contraseña en la tabla Preceptores
                sqlQuery = "SELECT COUNT(*) 
                            FROM Preceptores 
                            WHERE dni_prece = @Usuario AND StrComp(pass_prece, @Contraseña, 0) = 0"

            End If

            ' Se utiliza la estructura Using para asegurar que la conexión se cierre automáticamente
            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(sqlQuery, connection)

                    ' Parámetros para evitar la inyección de SQL. Y ayudar a que las consultas sean más claras
                    command.Parameters.AddWithValue("@Usuario", usuario)
                    command.Parameters.AddWithValue("@Contraseña", contraseña)

                    Try
                        ' Se abre la conexión
                        connection.Open()

                        ' ExecuteScalar() ejecuta la consulta y devuelve un valor que representa el conteo de registros
                        Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())

                        ' Se verifica si el conteo es mayor que 0. Si es mayor,
                        ' significa que las credenciales son válidas y se muestra el formulario correspondiente
                        If result > 0 Then

                            ' Se oculta el formulario actual
                            Me.Hide()

                            If rdBtnEstu.Checked = True Then
                                ' Se muestra el Formulario correspondiente
                                frmAsistenciaEstu.Show()
                            Else
                                ' Se muestra el Formulario correspondiente
                                frmPrece.Show()
                            End If

                        Else
                            ' Mensaje por ventana emergente
                            MsgBox("Nombre de usuario o contraseña incorrectos.")
                        End If

                    Catch ex As Exception
                        MsgBox("Error al iniciar sesión: " & ex.Message)
                    End Try

                End Using  ' La conexión se cerrará automáticamente aquí
            End Using
        Else
            MsgBox("No se permiten campos vacíos")
        End If
    End Sub


    Private Sub txtBxUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxUsuario.KeyPress
        ' Se llama a la función correspondiente que se encuentra en un Módulo
        modValidaciones.soloNumeros(e)  ' Se pasa la variable (e) que contiene el evento que será analizado
    End Sub

    '*******************************- COMPORTAMIENTO DEL BOTÓN SALIR -*******************************
    Private Sub btnSalirAcceso_Click(sender As Object, e As EventArgs) Handles btnSalirAcceso.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub

    Private Sub btnSalirAcceso_MouseHover(sender As Object, e As EventArgs) Handles btnSalirAcceso.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirAcceso.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirAcceso_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirAcceso.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirAcceso.BackgroundImage = My.Resources.apagarN_small
    End Sub
    '*************************************************************************************************

End Class




'+++++++++++++++++++++++++++- DETALLES DE LA FUNCIÓN StrComp() -+++++++++++++++++++++++++++++++++++++++
' StrComp(string1, string2, modoComparacion)
' string1 y String 2 son las cadenas a comparar.
' modoComparacion es cómo se comparan las cadenas, pudiendo ser "Binario" (valor 0) que distingue
' las mayúsculas de minúsculas y "Texto" (valor 1) que no distingue mayúsculas de minúsculas.

' La función devuelve 0 si las cadenas son iguales. Si no lo son, devuelve 1 o -1.
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++