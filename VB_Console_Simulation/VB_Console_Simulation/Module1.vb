Module Module1

    Public reorderPoint As Integer = 25

    Public orderSize As Integer = 35

    Sub Main()
        Randomize()


        Dim profit As Integer = (8 - 4)
        Dim avg As Double = 0
        Dim s As Integer = 0
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
        Do While (i <= 28)
            Dim demand As Integer = getRandomDayDemand()
            stock = (stock - demand)
            If (i = receiveDay) Then
                receiveDay = -1
                stock = (stock + orderSize)
                hasActiveOrder = False
            End If

            If (stock < 0) Then
                lostClients = (lostClients + Math.Abs(stock))
                stock = 0
            End If

            If ((stock <= reorderPoint) And (Not hasActiveOrder)) Then
                receiveDay = (getRandomLeadTime() + i)
                hasActiveOrder = True
            End If

            i = (i + 1)
        Loop

        Return lostClients
    End Function

    Private Function getRandomLeadTime() As Integer
        Dim r = Rnd()
        If (r < 0.285714286) Then
            Return 2
        ElseIf (r < 0.642857143) Then
            Return 3
        Else
            Return 4
        End If

    End Function

    Private Function getRandomDayDemand() As Integer
        Dim r = Rnd()
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
