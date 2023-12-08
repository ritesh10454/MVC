#Region "Interface"
Interface IissueVoucher(Of T)
    Function View(ByVal args As T) As QueryResponse(Of T)
    Function Insert(ByVal args As T) As QueryResponse(Of T)
    Function Delete(ByVal args As T) As QueryResponse(Of T)
    Function Update(ByVal args As T) As QueryResponse(Of T)
    Function View() As QueryResponse(Of T)
End Interface

#End Region
