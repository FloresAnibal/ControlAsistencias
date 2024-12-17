Imports System.Text.RegularExpressions
Module modValidaciones

    Public Sub soloNumeros(ByVal e As KeyPressEventArgs)
        ' Permite solo números y teclas de control (backspace, delete, etc.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    'En este código, estamos utilizando el evento KeyPress del TextBox. Cuando se presiona una tecla,
    'verificamos si es un dígito (Char.IsDigit) o una tecla de control (Char.IsControl). Si la tecla
    'no es un número o una tecla de control, cancelamos la entrada (e.Handled = True), lo que significa
    'que no se mostrará en el TextBox.


    Public Sub soloLetras(ByVal e As KeyPressEventArgs)
        ' Verificar si la tecla presionada es una letra
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Si no es una letra o una tecla de control, cancela la entrada
            e.Handled = True
        End If
    End Sub
    'En este código, estamos utilizando el evento KeyPress del TextBox. Cuando se presiona una tecla,
    'verificamos si es una letra (Char.IsLetter) o una tecla de control (Char.IsControl). Si la tecla
    'no es una letra o una tecla de control, cancelamos la entrada (e.Handled = True), lo que significa
    'que no se mostrará en el TextBox.



    ' Función para verificar si todos los TextBox tienen contenido


    Public Function camposLlenos(campos As TextBox()) As Boolean
        ' Itera sobre cada TextBox en el array
        For Each campo As TextBox In campos
            ' Verifica si el texto en el TextBox está vacío o es nulo
            If String.IsNullOrEmpty(campo.Text) Then
                ' Si al menos un campo está vacío, retorna False
                Return False
            End If
        Next

        ' Si todos los campos tienen contenido, retorna True
        Return True
    End Function


    Public Sub soloFecha(ByVal textBox As TextBox)
        Dim fecha As Date

        If Not Date.TryParse(textBox.Text, fecha) Then
            ' Si el contenido del TextBox no es una fecha válida, muestra un mensaje de error
            MessageBox.Show("Por favor, ingrese una fecha válida en el formato correcto (ejemplo: 01/01/2023).", "Error de formato")
            textBox.Clear() ' Borra el contenido del TextBox
        End If
    End Sub


    Public Sub soloMail(ByVal textBox As TextBox)
        ' Verifica que la cadena ingresada cumpla con las convenciones básicas de una dirección de correo
        ' electrónico, incluyendo un nombre de usuario seguido de "@" y un dominio válido

        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        Dim regex As New Regex(emailPattern)

        If Not regex.IsMatch(textBox.Text) Then
            MessageBox.Show("La dirección de correo electrónico ingresada no es válida. Por favor, ingrese una dirección de correo válida.", "Error de formato")
            textBox.Focus() ' Devuelve el foco al TextBox para corregir la entrada.
        End If
    End Sub


End Module

' La expresión regular `emailPattern` se compone de la siguiente manera:

' `^`:  Este carácter indica el inicio de la cadena, lo que significa que la dirección de correo electrónico
'       debe comenzar desde el principio de la cadena.

' `[a-zA-Z0-9._%+-]+`:  Esta parte de la expresión regular permite letras en minúsculas (`a-z`), letras en
'                       mayúsculas (`A-Z`), dígitos numéricos (`0-9`), así como algunos caracteres especiales
'                       como punto (`.`), guión bajo (`_`), porcentaje (`%`) y signo más (`+`). Esto permite
'                       que se ingresen caracteres comunes en las direcciones de correo electrónico.

' `@`: Es un carácter literal que debe coincidir con el símbolo "@" en una dirección de correo electrónico.

' `[a-zA-Z0-9.-]+`: Esta parte de la expresión regular permite letras en minúsculas (`a-z`), letras en mayúsculas
'                   (`A-Z`), dígitos numéricos (`0-9`), así como los caracteres punto (`.`) y guión (`-`) que
'                   suelen aparecer en el dominio del correo electrónico.

' `\.`: Esto representa un punto literal (`.`), y se usa para separar el nombre de usuario del dominio.

' `[a-zA-Z]{2,4}`:  Aquí se espera un dominio que consista en letras en minúsculas o mayúsculas, y tiene una
'                   longitud de 2 a 4 caracteres. Esto se utiliza para asegurarse de que el dominio tenga una
'                   extensión como ".com" o ".net".

' `$`: Indica el final de la cadena, lo que significa que la dirección de correo electrónico debe terminar allí.



'*********************************************************************************************************************


' La propiedad e.Handled en el evento KeyPress de un TextBox (u otros controles) es una propiedad booleana
' que indica si el evento ha sido manejado completamente y si no es necesario realizar más acciones para
' manejar la entrada de teclado asociada con ese evento.
' Cuando estableces e.Handled = True, estás indicando que has manejado completamente la entrada y no se deben
' realizar más acciones para procesarla. Esto evita que la tecla presionada se muestre en el control. En el
' caso de un TextBox, si estableces e.Handled = True, la tecla no se mostrará en el TextBox.
' Si estableces e.Handled = False, estás indicando que no has manejado completamente la entrada y que el
' control debe continuar procesándola. Esto permitiría que la tecla presionada se muestre normalmente en el
' control.
' En el contexto de restringir la entrada a ciertos tipos de caracteres (por ejemplo, solo letras o solo
' números), e.Handled = True se usa para cancelar la entrada de caracteres no deseados y asegurar que solo
' los caracteres permitidos se muestren en el control.
' Por ejemplo, en el caso de permitir solo letras en un TextBox, establecer e.Handled = True cuando la tecla
' presionada no es una letra indica que no deseas que se muestre esa tecla en el TextBox, lo que es esencial
' para restringir la entrada solo a letras.
