Imports System.Data.OleDb


Public Class frmCargaDatos

    ' Array de tipo TextBox
    Dim campos() As TextBox

    Private Sub frmCargaDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga del array con todos los TextBox del formulario
        campos = {txtBxNombres, txtBxApellido, txtBxDni, txtBxFechaNacimiento, txtBxCorreo, txtBxTelefono, txtBxCalle, txtBxAltura}
    End Sub

    Private Sub btnGuardarDatos_Click(sender As Object, e As EventArgs) Handles btnGuardarDatos.Click

        ' Función que comprueba si hay campos nulos o vacíos
        If campos.Any(Function(txbx) String.IsNullOrEmpty(txbx.Text)) Then
            MsgBox("Hay campos vacíos")
            Return
        End If

        Try
            Dim con As String = "Provider=Microsoft.ACE.OLEDB.16.0; Data Source=E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

            Using connDB As New OleDbConnection(con)
                connDB.Open()
                Using comd As New OleDbCommand("INSERT INTO Estudiantes (nomb_estu, apell_estu, dni_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu) 
                                                VALUES (@Nom, @Ape, @Dni, @Nac, @Tel, @Cor, @Cal, @Alt)", connDB)
                    ' Asignar parámetros
                    comd.Parameters.AddWithValue("@Nom", txtBxNombres.Text)
                    comd.Parameters.AddWithValue("@Ape", txtBxApellido.Text)
                    comd.Parameters.AddWithValue("@Dni", txtBxDni.Text)
                    comd.Parameters.AddWithValue("@Nac", txtBxFechaNacimiento.Text)
                    comd.Parameters.AddWithValue("@Tel", txtBxTelefono.Text)
                    comd.Parameters.AddWithValue("@Cor", txtBxCorreo.Text)
                    comd.Parameters.AddWithValue("@Cal", txtBxCalle.Text)
                    comd.Parameters.AddWithValue("@Alt", txtBxAltura.Text)

                    comd.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("El estudiante se registró correctamente.")

            ' Vaciar los TextBox llamando a la función que lo hará
            Vaciar()

        Catch ex As Exception
            MsgBox("Error al registrar el estudiante: " & ex.Message) ' & ex.Message Muestra información acerca del error
        End Try
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ' Cambiamos el nombre del botón
        If btnNuevo.Text = "Nuevo" Then
            btnNuevo.Text = "Cancelar"

            ' Habilitar todos los TextBox  
            For Each campo As TextBox In campos
                campo.Enabled = True
            Next

            btnGuardarDatos.Enabled = True

        Else
            ' Cambiamos el nombre del botón
            If btnNuevo.Text = "Cancelar" Then
                btnNuevo.Text = "Nuevo"

                ' Vaciar los TextBox llamando a la función que lo hará 
                Vaciar()

                ' Bloquar todos los TextBox  
                For Each campo As TextBox In campos
                    campo.Enabled = False
                Next

                btnGuardarDatos.Enabled = False
                btnEditar.Enabled = False


            Else
            End If
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Dim connDB As New OleDbConnection
        Dim oDataSet As New DataSet
        Dim comd As OleDbCommand
        Dim con, base As String

        If btnEditar.Text = "Editar" Then
            btnEditar.Text = "Actualizar"
            txtBxNombres.Enabled = True
            txtBxApellido.Enabled = True
            txtBxDni.Enabled = True
            txtBxFechaNacimiento.Enabled = True
            txtBxTelefono.Enabled = True
            txtBxCorreo.Enabled = True
            txtBxCalle.Enabled = True
            txtBxAltura.Enabled = True
        Else


            Try
                con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & base
                connDB = New OleDbConnection(con)
                ''''***
                connDB.Open()
                comd = New OleDb.OleDbCommand
                comd.Connection = connDB
                'comd.CommandText = "UPDATE Clientes SET NomCli ='" &
                'txtNomCli.Text & "', dniCli='" & txtDniCli.Text & "', telCli='" &
                'txtTelCli.Text & "', direCli='" & txtDireCli.Text & "' WHERE IdCli = " &
                'lblIdCli.Text & ""

                comd.ExecuteNonQuery()
                connDB.Close()

                MsgBox("Los datos del cliente se actualizaron correctamente.", vbInformation)
                'cmdEditar.Text = "Editar"
                'txtNomCli.Enabled = False
                'txtDniCli.Enabled = False
                'txtTelCli.Enabled = False
                'txtDireCli.Enabled = False

            Catch
                MsgBox("Error. Contacte al servicio técnico.", vbCritical)
            End Try
        End If

    End Sub

    Private Sub Vaciar()
        For Each campo As TextBox In campos
            campo.Text = ""
        Next
    End Sub

    Private Sub txtBxNombres_TextChanged(sender As Object, e As EventArgs) Handles txtBxNombres.TextChanged
        ' Ruta de la base de datos de Access
        Dim con As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

        ' Verificar si el cuadro de texto está vacío
        If txtBxNombres.Text = "" Then
            ' Ocultamos el ListView
            lstVwEstu.Visible = False
        Else
            Try
                ' Abrir la conexión a la base de datos utilizando la instrucción Using
                Using connDB As New OleDbConnection(con)
                    connDB.Open()
                    ' Consulta SQL para seleccionar solo el campo nomb_estu que comienza con el texto ingresado
                    Dim cmd As String = "SELECT nomb_estu FROM Estudiantes WHERE nomb_estu LIKE @NombreEstudiante"
                    ' Crear un adaptador de datos para ejecutar la consulta
                    Using oDataAdapter As New OleDbDataAdapter(cmd, connDB)
                        ' Asignar el valor del parámetro @NombreEstudiante
                        oDataAdapter.SelectCommand.Parameters.AddWithValue("@NombreEstudiante", txtBxNombres.Text & "%")
                        ' Crear un DataSet para almacenar los resultados de la consulta
                        Dim oDataSet As New DataSet()
                        ' Llenar el DataSet con los resultados de la consulta
                        oDataAdapter.Fill(oDataSet, "Estudiantes")

                        ' Verificar si se obtuvieron resultados
                        If oDataSet.Tables("Estudiantes").Rows.Count() <> 0 Then
                            ' Mostrar el ListView
                            lstVwEstu.Visible = True
                            ' Limpiar los elementos anteriores del ListView
                            lstVwEstu.Items.Clear()

                            ' Agregar cada resultado al ListView
                            For Each fila As DataRow In oDataSet.Tables("Estudiantes").Rows
                                lstVwEstu.Items.Add(fila("nomb_estu"))
                            Next
                        Else
                            ' Ocultar el ListView si no hay resultados
                            lstVwEstu.Visible = False
                        End If
                    End Using
                End Using
            Catch ea As Exception
                ' Mostrar mensaje de error si ocurre una excepción
                MsgBox(ea.Message)
            End Try
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Cargamos el contenido del TextBox para realizar la búsqueda por número de documento
        Dim dni As String = txtBxDni.Text
        Try
            Dim con As String = "Provider=Microsoft.ACE.OLEDB.16.0; Data Source=E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

            Using connDB As New OleDbConnection(con)
                connDB.Open()

                ' Consulta SQL para obtener los datos del estudiante por su DNI
                Dim sqlQuery As String = "SELECT nomb_estu, apell_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu
                                        FROM Estudiantes WHERE dni_estu = @Dni"

                Using command As New OleDbCommand(sqlQuery, connDB)
                    command.Parameters.AddWithValue("@Dni", dni)

                    Using reader As OleDbDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Asignar los valores a los TextBox correspondientes
                            txtBxNombres.Text = reader("nomb_estu").ToString()
                            txtBxApellido.Text = reader("apell_estu").ToString()
                            ' Usamos ToShortDateString para obtener solo la fecha en formato de cadena corta
                            txtBxFechaNacimiento.Text = reader("fecha_nac_estu").ToShortDateString()
                            txtBxTelefono.Text = reader("nro_tel_estu").ToString()
                            txtBxCorreo.Text = reader("email_estu").ToString()
                            txtBxCalle.Text = reader("calle_estu").ToString()
                            txtBxAltura.Text = reader("altura_calle_estu").ToString()
                        Else
                            MsgBox("No se encontraron datos para el DNI proporcionado.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al obtener datos del estudiante: " & ex.Message)
        End Try


    End Sub
End Class


'*************************************************************************
'ESTE CÓDIGO ES UNA FUNCIÓN SIMPLIFICADA PARA VALIDAR CAMPOS
'If campos.Any(Function(txbx) String.IsNullOrEmpty(txbx.Text)) Then
'    MsgBox("Hay campos vacíos")
'    Return
'End If

'ESTE SERÍA EL CÓDIGO NORMAL EQUIVALENTE A LA FUNCIÓN DE ARRIBA
'If HayCamposVacios(campos) Then
'    MsgBox("Hay campos vacíos")
'    Return
'End If

'Function HayCamposVacios(textBoxes() As TextBox) As Boolean
'    For Each txbx As TextBox In textBoxes
'        If String.IsNullOrEmpty(txbx.Text) Then
'            Return True ' Hay un campo vacío, retorna True
'        End If
'    Next
'    Return False ' No hay campos vacíos, retorna False
'End Function
'***************************************************************************