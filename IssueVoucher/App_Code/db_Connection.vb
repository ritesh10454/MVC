Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public MustInherit Class db_Connection
    Protected con As New SqlConnection()
    Protected cmd As New SqlCommand()
    Protected dat As New SqlDataAdapter()
    Protected dr As SqlDataReader()

    Private var_sql_con As SqlConnection

    Public Property sql_con() As SqlConnection
        Get
            Return var_sql_con
        End Get
        Set(ByVal value As SqlConnection
)
            var_sql_con = value
        End Set
    End Property


    Public Sub New(ByVal constr As String)
        con.ConnectionString = ConfigurationManager.ConnectionStrings(constr).ConnectionString
        Me.sql_con = con
    End Sub

    Protected Sub openConnection()
        If (con Is Nothing) Then con = Me.sql_con

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub

    Protected Sub closeConnection()
        con.Close()
    End Sub

End Class


