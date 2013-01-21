Imports System.Globalization

Public Class Form1
    Dim baseDatetime As Date
    Dim zones As Collections.Hashtable
    Dim culture As CultureInfo
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        zones = New Hashtable() ' Set up data container
        culture = New CultureInfo("en-GB") ' Import culture-specific formatters
        tz_list.Nodes.Clear()
        For Each tz As TimeZoneInfo In TimeZoneInfo.GetSystemTimeZones() ' YES I WENT THERE
            tz_list.Nodes.Add(tz.DisplayName, tz.DisplayName) ' Add the zones to the treeview...
            zones.Add(tz.DisplayName, tz) ' ... and to the list which stores the actual TimeZoneInfo objects.
        Next
        tz_list.SelectedNode = tz_list.Nodes("(UTC) Dublin, Edinburgh, Lisbon, London") ' Let's start at home
    End Sub

    Private Sub clockTick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clockTick.Tick
        baseDatetime = Date.UtcNow ' UTC is equivalent to GMT +0
        Dim converted As Date = TimeZoneInfo.ConvertTimeFromUtc(baseDatetime, zones(tz_list.SelectedNode.Text)) ' Convert base UTC time to selected timezone
        If check_24h.Checked Then ' This is why the checkbox events are not handled.
            lbl_TimeDisplay.Text = converted.ToString("HH:mm:ss", culture) ' 24h time
        Else
            lbl_TimeDisplay.Text = converted.ToString("hh:mm:ss tt", culture) ' 12h time
        End If
        AnalogueClock1.SetTime(converted) ' Update the analogue clock too
    End Sub
End Class
