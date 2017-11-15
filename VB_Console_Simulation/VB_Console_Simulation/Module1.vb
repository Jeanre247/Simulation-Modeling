Module Module1

    ' global variables
    Private reorderPoint As Integer = 25
    Private orderSize As Integer = 35

    Sub Main()
        Randomize()


        Dim profit As Integer = (8 - 4)
        Dim avg As Double = 0
        Dim s As Integer = 0

        ' do while loop to simulate the month 1000 times
        ' And display the average loss
        Do While (s < 1000)
            avg += simulateMonth() * profit

            s = (s + 1)
        Loop

        avg = (avg / 1000)
        Console.WriteLine("Average profit lost for January 2018:")
        Console.WriteLine(avg)
        Console.WriteLine("Simulation was run 1000 times.")
        Console.ReadLine()

    End Sub

    Public Function simulateMonth() As Integer
        Dim receiveDay As Integer = -1
        Dim stock As Integer = 0
        Dim lostClients As Integer = 0
        Dim hasActiveOrder As Boolean = False
        Dim i As Integer = 1

        ' do while loop to run through the business days of the month.
        Do While (i <= 28)
            Dim demand As Integer = getRandomDayDemand()
            stock = (stock - demand) ' Subtract the sales (demand) from the stock.

            ' stock received on this day.
            If (i = receiveDay) Then
                receiveDay = -1
                stock = (stock + orderSize)
                hasActiveOrder = False
            End If

            ' lost sales/clients due to stock outage.
            If (stock < 0) Then
                lostClients = (lostClients + Math.Abs(stock))
                stock = 0
            End If

            ' reorder stock at reorder Point of 25
            If ((stock <= reorderPoint) And (Not hasActiveOrder)) Then
                receiveDay = (getRandomLeadTime() + i)
                hasActiveOrder = True
            End If

            i = (i + 1)
        Loop

        Return lostClients
    End Function

    ' Generate an accurate lead time for given order.
    Private Function getRandomLeadTime() As Integer
        Dim r = Rnd()

        ' Use data from LeadTimeData sheet in excel document.
        If (r < 0.285714286) Then
            Return 2
        ElseIf (r < 0.642857143) Then
            Return 3
        Else
            Return 4
        End If

    End Function

    ' Generate an accurate demand (sales) for given day.
    Private Function getRandomDayDemand() As Integer
        Dim r = Rnd()

        ' Use data from DayleDemand sheet in excel document.
        If (r < 0.261306533) Then
            Return 5
        ElseIf (r < 0.48241206) Then
            Return 6
        ElseIf (r < 0.804020101) Then
            Return 7
        Else
            Return 8
        End If

    End Function

End Module
