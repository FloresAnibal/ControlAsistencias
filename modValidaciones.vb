Module modValidaciones
    Public Sub soloNumeros(ByVal e As KeyPressEventArgs)
        ' Permite solo números y teclas de control (backspace, delete, etc.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    ' Función para verificar si todos los TextBox tienen contenido
    Public Function camposLlenos(campos As TextBox()) As Boolean
        ' Itera sobre cada TextBox en el array
        For Each campo As TextBox In campos
            ' Verifica si el texto en el TextBox está vacío o es nulo
            If String.IsNullOrEmpty(campo.Text) Then
                ' Si al menos un campo está vacío, retorna False
                Return False ' Al menos un campo está vacío
            End If
        Next

        ' Si todos los campos tienen contenido, retorna True
        Return True ' Todos los campos tienen contenido
    End Function
End Module








'*********************************************************************************************************************


'La propiedad e.Handled en el evento KeyPress de un TextBox (u otros controles) es una propiedad booleana que indica si el evento ha sido manejado completamente y si no es necesario realizar más acciones para manejar la entrada de teclado asociada con ese evento.
'Cuando estableces e.Handled = True, estás indicando que has manejado completamente la entrada y no se deben realizar más acciones para procesarla. Esto evita que la tecla presionada se muestre en el control. En el caso de un TextBox, si estableces e.Handled = True, la tecla no se mostrará en el TextBox.
'Si estableces e.Handled = False, estás indicando que no has manejado completamente la entrada y que el control debe continuar procesándola. Esto permitiría que la tecla presionada se muestre normalmente en el control.
'En el contexto de restringir la entrada a ciertos tipos de caracteres (por ejemplo, solo letras o solo números), e.Handled = True se usa para cancelar la entrada de caracteres no deseados y asegurar que solo los caracteres permitidos se muestren en el control.
'Por ejemplo, en el caso de permitir solo letras en un TextBox, establecer e.Handled = True cuando la tecla presionada no es una letra indica que no deseas que se muestre esa tecla en el TextBox, lo que es esencial para restringir la entrada solo a letras.
