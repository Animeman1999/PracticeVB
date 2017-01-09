Imports System.IO
''' <summary>
''' Class to read and write to a CSV file
''' </summary>
Public Class CSVInterface
    ''' <summary>
    ''' Method to read in a CSV File. 
    ''' </summary>
    ''' <param name="csvFilePath">String</param>
    ''' <param name="wineCollection">WineItem</param>
    Public Sub ReadCSVFile(csvFilePath As String, wineCollection As WineCollection)
        Dim streamReader As StreamReader

        Try
            streamReader = New StreamReader(csvFilePath)
            Dim counter As Integer = 0
            Dim inputString As String
            While streamReader.EndOfStream = False
                inputString = streamReader.ReadLine()
                ProcessRecord(inputString, wineCollection, counter)
                counter += 1
            End While
        Catch e As Exception
            Console.WriteLine(e.ToString())
            Console.WriteLine()
            Console.WriteLine(e.StackTrace)
        Finally
            If streamReader IsNot Nothing Then
                streamReader.Close()
            End If

        End Try

    End Sub

    ''' <summary>
    ''' Method to parse out one line of read in wine data and create a wine item
    ''' </summary>
    ''' <param name="inputString">String</param>
    ''' <param name="wineCollection">WineItem</param>
    ''' <param name="index">Integer</param>
    Private Sub ProcessRecord(inputString As String, wineCollection As WineCollection, index As Integer)
        Dim inputParts() As String
        inputParts = inputString.Split(",")
        Dim id As String = inputParts(0)
        Dim description As String = inputParts(1)
        Dim pack As String = inputParts(2)

        wineCollection.addWineItem(id, description, pack)
    End Sub

End Class
