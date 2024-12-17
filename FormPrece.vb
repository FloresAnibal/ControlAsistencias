Public Class frmPrece

    Private Sub btnAsitencias_Click(sender As Object, e As EventArgs) Handles btnAsitencias.Click
        Me.Hide()
        frmCargaAsis.Show()
    End Sub

    Private Sub btnRegistros_Click(sender As Object, e As EventArgs) Handles btnRegistros.Click
        Me.Hide()
        frmCargaDatos.Show()
    End Sub


    '*******************************- COMPORTAMIENTO DEL BOTÓN SALIR -*******************************
    Private Sub btnSalirPrece_Click(sender As Object, e As EventArgs) Handles btnSalirPrece.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub

    Private Sub btnSalirPrece_MouseHover(sender As Object, e As EventArgs) Handles btnSalirPrece.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirPrece.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirPrece_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirPrece.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirPrece.BackgroundImage = My.Resources.apagarN_small
    End Sub

    '*************************************************************************************************

End Class