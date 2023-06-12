Imports Santec
Imports Santec.STSProcess
Public Class Form1
    Private TSL As New TSL                                              'TSL Control Class
    Private MPM() As MPM                                                'MPM Control Class
    Private SPU As New SPU                                              'SPU Control Class
    Private PCU As New PCU                                              'PCU Control Class
    Private Cal_STS As New PDLSTS                                       'STS Calucrate Class   PDLSTS Class -> Sub class of ILSTS   
    Private Data_struct As New List(Of STSDataStruct)                   'STS data Struct for Measure
    Private Refdata_struct As New List(Of STSDataStruct)                'STS data Struct for Reference
    Private Mergedata_struct As New List(Of STSDataStructForMerge)      'Data struct for merge  
    Private Ref_monitordata_struct As New List(Of STSDataStruct)        'STS Monitor data Struct for Reference
    Private Meas_monitordata_struct As New List(Of STSMonitorStruct)    'STS Monitor data struct for Measure
    Private Meas_rang As New List(Of Integer)                           'Measurement Range 
    Private Flag_213 As Boolean                                         'Exist 213 flag      T: Exist F: nothing
    Private Flag_215 As Boolean                                         'Exist 215 flag      T: Exist F: nothing 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-------------------------------------------------------------------------
        '       Form Load    (MainForm)
        '-------------------------------------------------------------------------
        Dim spudev() As String = Nothing                        'SPU device name
        Dim errorcode As Integer                                'errorcode 
        Dim usb_resource() As String = Nothing                  'usb communication resource



        '----Check Connction of spu deviece
        errorcode = SPU.Get_Device_ID(spudev)
        If errorcode <> 0 Then
            Show_Inst_Error(errorcode)
            End
        End If


        '----Check usb resource
        usb_resource = Communication.MainCommunication.Get_USB_Resouce


        '------show Setting Form
        Dim set_form As New Instrument_Setting

        set_form.Owner = Me
        set_form.SPU_Resource = spudev
        set_form.USB_Resource = usb_resource

        set_form.ShowDialog()

        '-------Apply to communication parametere from Instrument setting form---
        Dim tsl_communcation_method As Communication.CommunicationMethod            'communication method for TSL
        Dim mpm_communcation_method As Communication.CommunicationMethod            'communication method for MPM    
        Dim pcu_communcation_method As Communication.CommunicationMethod            'communication methode for PCU


        '----TSL　Communication setting -------------------------------------
        If set_form.TSL_Communicater = "GPIB" Then
            'GPIB
            tsl_communcation_method = Communication.CommunicationMethod.GPIB
            TSL.Terminator = CommunicationTerminator.CrLf
            TSL.GPIBAddress = set_form.TSL_Address
            TSL.GPIBBoard = 0
            TSL.GPIBConnectType = Communication.GPIBConnectType.NI4882


        ElseIf set_form.TSL_Communicater = "LAN" Then
            'LAN
            tsl_communcation_method = Communication.CommunicationMethod.TCPIP
            TSL.Terminator = CommunicationTerminator.Cr
            TSL.IPAddress = set_form.TSL_Address
            TSL.Port = set_form.TSL_Portnumber
        Else
            'USB 
            tsl_communcation_method = Communication.CommunicationMethod.USB
            TSL.DeviceID = CInt(set_form.TSL_Address)
            TSL.Terminator = CommunicationTerminator.Cr
        End If


        '---MPM Communication setting --------------------------------------
        Dim loop1 As Integer
        Dim mpmcount As Integer                     'MPM count


        If set_form.MPM_Communicater = "GPIB" Then
            'GPIB
            mpm_communcation_method = Communication.CommunicationMethod.GPIB
        Else
            'LAN
            mpm_communcation_method = Communication.CommunicationMethod.TCPIP
        End If

        mpmcount = set_form.MPM_Count
        ReDim MPM(mpmcount - 1)

        For loop1 = 0 To mpmcount - 1

            MPM(loop1) = New MPM

            If set_form.MPM_Communicater = "GPIB" Then
                MPM(loop1).GPIBAddress = set_form.MPM_Address(loop1)
            Else
                MPM(loop1).IPAddress = set_form.MPM_Address(loop1)
                MPM(loop1).Port = set_form.MPM_Portnumber(loop1)
            End If

            ' muximum logging data reading time = 11s
            MPM(loop1).TimeOut = 11000

        Next


        '-------PCU Communcation setting-------------------------
        If set_form.PCU_Communicater = "GPIB" Then
            'GPIB
            pcu_communcation_method = Communication.CommunicationMethod.GPIB
            PCU.GPIBAddress = set_form.PCU_Address
            PCU.GPIBBoard = 0
            PCU.Terminator = CommunicationTerminator.CrLf

        ElseIf set_form.PCU_Communicater = "LAN" Then
            'LAN
            pcu_communcation_method = Communication.CommunicationMethod.TCPIP
            PCU.IPAddress = set_form.PCU_Address
            PCU.Port = set_form.PCU_Portnumber

        Else
            'USB
            pcu_communcation_method = Communication.CommunicationMethod.USB
            PCU.DeviceID = CInt(set_form.PCU_Address)
            PCU.Terminator = CommunicationTerminator.Cr                     'PCU USB Command follow only "Cr"  terminator

        End If


        '----Using PCU inside DAQ or not
        If set_form.PCU_useing_internal_DAQ = True Then
            'inside 
            PCU.DeviceName = set_form.SPU_DeviveID
        End If


        '------SPU Communcation Setting 
        SPU.DeviceName = set_form.SPU_DeviveID


        '-----Connect----------------------------------------------------------- 
        errorcode = TSL.Connect(tsl_communcation_method)                        'TSL

        If errorcode <> 0 Then
            MsgBox("TSL can't connect.Please check connection.", vbOKOnly)
            End
        End If


        For loop1 = 0 To UBound(MPM)                                            'MPM
            errorcode = MPM(loop1).Connect(mpm_communcation_method)

            If errorcode <> 0 Then
                MsgBox("mpm can't connect.Please check connection.", vbOKOnly)
                End
            End If
        Next

        Dim ans As String = String.Empty
        errorcode = SPU.Connect(ans)                                            'SPU

        If errorcode <> 0 Then
            MsgBox("SPU Can't connect. Please check connection.", vbOKOnly)
            End
        End If


        errorcode = PCU.Connect(pcu_communcation_method)                        'PCU
        If errorcode <> 0 Then
            MsgBox("PCU can't connect.Please check connection.", vbOKOnly)
            End
        End If

        '-----Check Module information--------------------------------------
        errorcode = Check_Module_Information()

        If errorcode <> 0 Then
            MsgBox("System can't use MPM-215 togeter other module", vbOKOnly)
            End
        End If

        '-----------Reflect instrument parameter to Form-------------------
        Referect_EnableCh_for_form()                'MPM Eanble ch
        Referect_EnableRange_for_form()             'MPM selectable range
        Add_TSL_Sweep_Speed()                       'TSL Sweep speed(only TSL-570)



    End Sub
    Private Function Add_TSL_Sweep_Speed() As Integer
        '---------------------------------------------------------
        '       Add in selectable sweep speed to speed combbox
        '       this function can use only TSL-570
        '----------------------------------------------------------
        Dim inst_error As Integer                       'instullment error
        Dim sweep_table() As Double = Nothing           'table


        ' Get Sweep speed tabele
        'Except for TSL-570 "Device Error" occurre when call this function.
        inst_error = TSL.Get_Sweep_Speed_table(sweep_table)

        If inst_error <> 0 And inst_error <> CInt(ExceptionCode.DeviceError) Then
            Return inst_error
        End If


        '-----Add in combbox when TSL-570
        Dim loop1 As Integer

        If inst_error <> CInt(ExceptionCode.DeviceError) Then

            For loop1 = 0 To UBound(sweep_table)

                Me.cmbspeed.Items.Add(sweep_table(loop1))
            Next
        End If
        Return 0

    End Function

    Private Function Check_Module_Information() As Integer
        '------------------------------------------------------------
        '       check Module information inside system
        '------------------------------------------------------------
        Dim loop1 As Integer
        Dim loop2 As Integer
        Dim counter_215 As Integer                           '215 counter 

        'MPM device loop
        For loop1 = 0 To UBound(MPM)
            'Slot loop
            For loop2 = 0 To 4
                'Enable Slot
                If MPM(loop1).Information.ModuleEnable(loop2) = True Then

                    'Check MPM-215 insert
                    If MPM(loop1).Information.ModuleType(loop2) = "MPM-215" Then
                        Flag_215 = True
                        counter_215 = counter_215 + 1
                    End If

                    'Check MPM-213 insert
                    If MPM(loop1).Information.ModuleType(loop2) = "MPM-213" Then
                        Flag_213 = True
                    End If

                End If
            Next

        Next


        'Check MPM-215 count & Module total count
        'STS system can't use 215 together other module.
        Dim enable_module_count As Integer                      'enable module count

        For loop1 = 0 To UBound(MPM)
            enable_module_count = MPM(loop1).Information.NumberofModule + enable_module_count       'total module count
        Next

        If Flag_215 = True Then
            If enable_module_count <> counter_215 Then
                Return -1
            End If
        End If
        Return 0

    End Function
    Private Sub Referect_EnableCh_for_form()
        '------------------------------------------------
        '       Reflect mpm ch 
        '------------------------------------------------
        Dim loop1 As Integer
        Dim loop2 As Integer
        Dim enable_slot() As Boolean
        Dim slot_type As String

        For loop1 = 0 To UBound(MPM)
            'get insert module count with "MPM Information" class 
            enable_slot = MPM(loop1).Information.ModuleEnable

            'modeule loop(Maximum 5 slot)
            For loop2 = 0 To 4
                If enable_slot(loop2) = True Then
                    'get module type with "MPM Information" class 
                    slot_type = MPM(loop1).Information.ModuleType(loop2)

                    If slot_type <> "MPM-212" Then
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch1")
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch2")
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch3")
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch4")
                    Else
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch1")
                        Me.chklst_ch.Items.Add("MPM" & CStr(loop1 + 1) & " Slot" & CStr(loop2) & " Ch2")
                    End If

                End If
            Next
        Next
    End Sub
    Private Sub Referect_EnableRange_for_form()
        '-----------------------------------------------------
        '       Refelect MPM Range
        '-------------------------------------------------------


        ' MPM-213 can use just 1 to 4 range
        If Flag_213 = True Then
            Me.chklst_range.Items.Add("Range1")
            Me.chklst_range.Items.Add("Range2")
            Me.chklst_range.Items.Add("Range3")
            Me.chklst_range.Items.Add("Range4")
        Else
            Me.chklst_range.Items.Add("Range1")
            Me.chklst_range.Items.Add("Range2")
            Me.chklst_range.Items.Add("Range3")
            Me.chklst_range.Items.Add("Range4")
            Me.chklst_range.Items.Add("Range5")
        End If

        ' MPM-215 can't select range
        If Flag_215 = True Then
            Me.chklst_range.Enabled = False
        End If

    End Sub

    Private Sub btnset_Click(sender As Object, e As EventArgs) Handles btnset.Click
        '-------------------------------------------------------------------------
        '           Set Parameter
        '--------------------------------------------------------------------------
        Dim startwave As Double             'Startwavelength(nm)
        Dim stopwave As Double              'Stopwavelength(nm)
        Dim set_pow As Double               'Power(dBm)
        Dim wavestep As Double              'wavelenthg step(nm)
        Dim speed As Double                 'Sweep Speed (nm/sec)
        Dim inst_error As Integer           'instullment error



        startwave = Me.txtstartwave.Text
        stopwave = Me.txtstopwave.Text
        wavestep = Me.txtstepwave.Text
        speed = Me.cmbspeed.Text
        set_pow = Me.txtpower.Text



        '---------TSL Setting--------------------------------------------------- 
        Dim tsl_acctualstep As Double          ' TSL output trigger step(nm)


        'set Power
        inst_error = TSL.Set_APC_Power_dBm(set_pow)
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        'set Sweep parameter
        inst_error = TSL.Set_Sweep_Parameter_for_STS(startwave, stopwave, speed, wavestep, tsl_acctualstep)
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        'wavelength -> start wavelength
        inst_error = TSL.Set_Wavelength(startwave)
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        'busy check
        inst_error = TSL.TSL_Busy_Check(3000)
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If



        '------MPM setting ------------------------------------------------------------
        Dim loop1 As Integer

        For loop1 = 0 To UBound(MPM)
            'Sweep parameter setting 
            inst_error = MPM(loop1).Set_Logging_Paremeter_for_STS(startwave, stopwave, wavestep, speed, Santec.MPM.Measurement_Mode.Freerun)
            If inst_error <> 0 Then
                Show_Inst_Error(inst_error)
                Exit Sub
            End If
        Next


        '---SPU setting ----------------------------------------------------------------
        Dim averaging_time As Double

        'Get MPM averaging time
        inst_error = MPM(0).Get_Averaging_Time(averaging_time)

        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        'parameter setting 
        inst_error = SPU.Set_Sampling_Parameter(startwave, stopwave, speed, tsl_acctualstep)

        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        'mpm averageing time-> spu
        SPU.AveragingTime = averaging_time

        '-----PCU setting --------------------------------------------------------------
        'PCU range adjust must set to be after TSL Power set.
        inst_error = PCU.Range_Adjust()

        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Exit Sub
        End If

        '-------------set STS Process parameter-----------------------------------------
        Dim sts_error As Integer            'sts process class error

        'Data Clear 
        sts_error = Cal_STS.Clear_Measdata()

        If sts_error <> 0 Then
            Show_STS_Error(sts_error)
            Exit Sub
        End If

        sts_error = Cal_STS.Clear_Refdata

        If sts_error <> 0 Then
            Show_STS_Error(sts_error)
            Exit Sub
        End If

        'Setting for STS rescaling mode
        sts_error = Cal_STS.Set_Rescaling_Setting(RescalingMode.Freerun_SPU, averaging_time, True)

        If sts_error <> 0 Then
            Show_STS_Error(sts_error)
            Exit Sub
        End If

        'Make acctual wavelength step table
        sts_error = Cal_STS.Make_Sweep_Wavelength_Table(startwave, stopwave, tsl_acctualstep)

        If sts_error <> 0 Then
            Show_STS_Error(sts_error)
            Exit Sub
        End If

        'Make rescaling wavelength step table
        sts_error = Cal_STS.Make_Target_Wavelength_Table(startwave, stopwave, wavestep)

        If sts_error <> 0 Then
            Show_STS_Error(sts_error)
            Exit Sub
        End If

        '--------prepare data struct & hold instrument condition-------------------------
        If Me.chkeach_ch.Checked Then
            Prepare_dataST_Each()
        Else
            Prepare_dataST()
        End If

        MsgBox("Completed.", vbOKOnly)
    End Sub

    Private Sub Prepare_dataST()
        '----------------------------------------------
        '       Prepar STS data struct
        '-----------------------------------------------
        Dim rangecout As Integer                        'number of range
        Dim chcount As Integer                          'number of ch 
        Dim chloop As Integer                           'channel loop
        Dim rangeloop As Integer                        'range loop
        Dim soploop As Integer                          'sop loop
        Dim text_st As String = String.Empty            'text String 
        Dim split_st() As String = Nothing              'split string array

        '-----Clear List data
        Meas_rang.Clear()
        Data_struct.Clear()
        Refdata_struct.Clear()
        Ref_monitordata_struct.Clear()
        Meas_monitordata_struct.Clear()
        Mergedata_struct.Clear()


        rangecout = Me.chklst_range.CheckedItems.Count   'number of range
        chcount = Me.chklst_ch.CheckedItems.Count        'number of channel
        If Flag_215 = True Then
            'If mom215 range must be set 1
            Meas_rang.Add(1)
        Else
            If rangecout = 0 Or chcount = 0 Then
                MsgBox("Please check measurement parameters.", vbOKOnly)
                Exit Sub
            End If
            'hold  data of range number  
            For loop1 = 0 To Me.chklst_range.Items.Count - 1
                If Me.chklst_range.GetItemChecked(loop1) = True Then
                    Meas_rang.Add(loop1 + 1)
                End If
            Next
        End If

        'Add in measurement condition of Data structure 
        Dim sopcount As Integer
        Dim device_number As Integer
        Dim slot_number As Integer
        Dim ch_number As Integer
        Dim set_struct As STSDataStruct
        Dim sweep_count As Integer = 1

        'for measurement power data
        For chloop = 0 To Me.chklst_ch.Items.Count - 1
            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                'ch parameter
                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))

                set_struct.MPMNumber = device_number
                set_struct.SlotNumber = slot_number
                set_struct.ChannelNumber = ch_number

                For rangeloop = 0 To Meas_rang.Count - 1

                    If Me.chk2scan.Checked = True And rangeloop <> 0 Then
                        sopcount = 2
                    Else
                        sopcount = 4
                    End If

                    set_struct.RangeNumber = Meas_rang(rangeloop)

                    For soploop = 0 To sopcount - 1

                        set_struct.SOP = soploop
                        set_struct.SweepCount = sweep_count
                        sweep_count = sweep_count + 1

                        Data_struct.Add(set_struct)
                    Next
                Next
                sweep_count = 1
            End If
        Next

        'for reference power data & mergedata 
        Dim set_merge_struct As STSDataStructForMerge
        set_struct = New STSDataStruct
        sweep_count = 1
        For chloop = 0 To Me.chklst_ch.Items.Count - 1
            If Me.chklst_ch.GetItemChecked(chloop) = True Then


                'ch parameter
                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))
                'for data
                set_struct.MPMNumber = device_number
                set_struct.SlotNumber = slot_number
                set_struct.ChannelNumber = ch_number
                set_struct.RangeNumber = 1
                'for merge
                set_merge_struct.MPMNumber = device_number
                set_merge_struct.SlotNumber = slot_number
                set_merge_struct.ChannelNumber = ch_number
                sopcount = 4

                'SOP loop
                For soploop = 0 To sopcount - 1
                    set_struct.SOP = soploop
                    set_struct.SweepCount = sweep_count

                    set_merge_struct.SOP = soploop

                    sweep_count = sweep_count + 1
                    Refdata_struct.Add(set_struct)                      'Add Data for Reference Struct
                    Mergedata_struct.Add(set_merge_struct)              'Add data for Merge Struct
                Next
                sweep_count = 1
            End If
        Next


        'for measurement monitor data
        Dim set_monitor_struct As STSMonitorStruct
        sweep_count = 1

        For chloop = 0 To Me.chklst_ch.Items.Count - 1

            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1

                set_monitor_struct.MPMNumber = device_number

                For rangeloop = 0 To Meas_rang.Count - 1

                    If Me.chk2scan.Checked = True And rangeloop <> 0 Then
                        sopcount = 2
                    Else
                        sopcount = 4
                    End If

                    For soploop = 0 To sopcount - 1
                        set_monitor_struct.SOP = soploop
                        set_monitor_struct.SweepCount = sweep_count
                        'Add
                        Meas_monitordata_struct.Add(set_monitor_struct)
                        sweep_count = sweep_count + 1
                    Next
                Next
                Exit For
            End If
        Next

        'for reference monitor data
        sweep_count = 1
        Dim set_ref_monitor_struct = New STSDataStruct
        For chloop = 0 To Me.chklst_ch.Items.Count - 1

            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))

                set_ref_monitor_struct.MPMNumber = device_number
                set_ref_monitor_struct.SlotNumber = slot_number
                set_ref_monitor_struct.ChannelNumber = ch_number
                set_ref_monitor_struct.RangeNumber = 1

                For soploop = 0 To 3
                    set_ref_monitor_struct.SOP = soploop
                    set_ref_monitor_struct.SweepCount = soploop + 1

                    Ref_monitordata_struct.Add(set_ref_monitor_struct)
                Next
                Exit For
            End If
        Next

    End Sub

    Private Sub Show_Inst_Error(ByVal errordata As Integer)
        '------------------------------------
        '       Show error code
        '------------------------------------


        Dim errorstring() As String = [Enum].GetNames(GetType(Santec.ExceptionCode))
        Dim errorvale() As Integer = [Enum].GetValues(GetType(Santec.ExceptionCode))
        Dim loop1 As Integer

        For loop1 = 0 To UBound(errorvale)

            If errorvale(loop1) = errordata Then
                MsgBox(errorstring(loop1))
                Exit For
            End If

        Next

    End Sub
    Private Sub Prepare_dataST_Each()
        '----------------------------------------------
        '       Prepar STS data struct
        '-----------------------------------------------
        Dim rangecout As Integer                        'number of range
        Dim chcount As Integer                          'number of ch 
        Dim chloop As Integer                           'channel loop
        Dim rangeloop As Integer                        'range loop
        Dim soploop As Integer                          'sop loop
        Dim text_st As String = String.Empty            'text String 
        Dim split_st() As String = Nothing              'split string array

        '-----Clear List data
        Meas_rang.Clear()
        Data_struct.Clear()
        Refdata_struct.Clear()
        Ref_monitordata_struct.Clear()
        Meas_monitordata_struct.Clear()
        Mergedata_struct.Clear()


        rangecout = Me.chklst_range.CheckedItems.Count   'number of range
        chcount = Me.chklst_ch.CheckedItems.Count        'number of channel
        If Flag_215 = True Then
            'If mom215 range must be set 1
            Meas_rang.Add(1)
        Else
            If rangecout = 0 Or chcount = 0 Then
                MsgBox("Please check measurement parameters.", vbOKOnly)
                Exit Sub
            End If
            'hold  data of range number  
            For loop1 = 0 To Me.chklst_range.Items.Count - 1
                If Me.chklst_range.GetItemChecked(loop1) = True Then
                    Meas_rang.Add(loop1 + 1)
                End If
            Next
        End If

        'Add in measurement condition of Data structure 
        Dim sopcount As Integer
        Dim device_number As Integer
        Dim slot_number As Integer
        Dim ch_number As Integer
        Dim set_struct As STSDataStruct
        Dim sweep_count As Integer = 1

        'for measurement power data
        For chloop = 0 To Me.chklst_ch.Items.Count - 1
            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                'ch parameter
                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))

                set_struct.MPMNumber = device_number
                set_struct.SlotNumber = slot_number
                set_struct.ChannelNumber = ch_number

                For rangeloop = 0 To Meas_rang.Count - 1

                    If Me.chk2scan.Checked = True And rangeloop <> 0 Then
                        sopcount = 2
                    Else
                        sopcount = 4
                    End If

                    set_struct.RangeNumber = Meas_rang(rangeloop)

                    For soploop = 0 To sopcount - 1

                        set_struct.SOP = soploop
                        set_struct.SweepCount = sweep_count
                        sweep_count = sweep_count + 1

                        Data_struct.Add(set_struct)
                    Next
                Next
                sweep_count = 1
            End If
        Next

        'for reference power data & reference monitor data
        set_struct = New STSDataStruct
        Dim set_ref_monitor_struct As STSDataStruct
        sweep_count = 1
        For chloop = 0 To Me.chklst_ch.Items.Count - 1
            If Me.chklst_ch.GetItemChecked(chloop) = True Then


                'ch parameter
                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))
                'for data
                set_struct.MPMNumber = device_number
                set_struct.SlotNumber = slot_number
                set_struct.ChannelNumber = ch_number
                set_struct.RangeNumber = 1

                'for monitor
                set_ref_monitor_struct.MPMNumber = device_number
                set_ref_monitor_struct.SlotNumber = slot_number
                set_ref_monitor_struct.ChannelNumber = ch_number
                set_ref_monitor_struct.RangeNumber = 1

                sopcount = 4

                'SOP loop
                For soploop = 0 To sopcount - 1
                    set_struct.SOP = soploop
                    set_struct.SweepCount = sweep_count

                    set_ref_monitor_struct.SOP = soploop
                    set_ref_monitor_struct.SweepCount = sweep_count

                    sweep_count = sweep_count + 1
                    Refdata_struct.Add(set_struct)                      'Add Data for Reference Struct
                    Ref_monitordata_struct.Add(set_ref_monitor_struct)  'Add monitor data for Reference Struct
                Next
                'sweep_count = 1
            End If
        Next

        'for mergedata 
        Dim set_merge_struct As STSDataStructForMerge
        sweep_count = 1
        For chloop = 0 To Me.chklst_ch.Items.Count - 1
            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                'ch parameter
                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1
                slot_number = CInt(split_st(1).Substring(4))
                ch_number = CInt(split_st(2).Substring(2))

                set_merge_struct.MPMNumber = device_number
                set_merge_struct.SlotNumber = slot_number
                set_merge_struct.ChannelNumber = ch_number
                sopcount = 4

                'SOP loop
                For soploop = 0 To sopcount - 1

                    set_merge_struct.SOP = soploop

                    sweep_count = sweep_count + 1
                    Mergedata_struct.Add(set_merge_struct)              'Add data for Merge Struct
                Next
                sweep_count = 1
            End If
        Next

        'for measurement monitor data
        Dim set_monitor_struct = New STSMonitorStruct
        sweep_count = 1

        For chloop = 0 To Me.chklst_ch.Items.Count - 1

            If Me.chklst_ch.GetItemChecked(chloop) = True Then

                text_st = Me.chklst_ch.Items(chloop)
                split_st = Split(text_st, " ")
                device_number = CInt(split_st(0).Substring(3)) - 1

                set_monitor_struct.MPMNumber = device_number

                For rangeloop = 0 To Meas_rang.Count - 1

                    If Me.chk2scan.Checked = True And rangeloop <> 0 Then
                        sopcount = 2
                    Else
                        sopcount = 4
                    End If

                    For soploop = 0 To sopcount - 1
                        set_monitor_struct.SOP = soploop
                        set_monitor_struct.SweepCount = sweep_count
                        'Add
                        Meas_monitordata_struct.Add(set_monitor_struct)
                        sweep_count = sweep_count + 1
                    Next
                Next
                Exit For
            End If
        Next


    End Sub


    Private Sub Show_STS_Error(ByVal errordata As Integer)
        '------------------------------------
        '       Show error code for STS
        '------------------------------------


        Dim errorstring() As String = [Enum].GetNames(GetType(Santec.STSProcess.ErrorCode))
        Dim errorvale() As Integer = [Enum].GetValues(GetType(Santec.STSProcess.ErrorCode))
        Dim loop1 As Integer

        For loop1 = 0 To UBound(errorvale)

            If errorvale(loop1) = errordata Then
                MsgBox(errorstring(loop1))
                Exit For
            End If

        Next

    End Sub

    Private Sub btnget_reference_Click(sender As Object, e As EventArgs) Handles btnget_reference.Click

        '------------------------------------------------------------------------------
        '           Get Reference
        '------------------------------------------------------------------------------
        Dim inst_error As Integer                       'Instullment error
        Dim inst_flag As Boolean



        'MPM setting for selected 1st range
        For loop1 = 0 To UBound(MPM)
            inst_error = MPM(loop1).Set_Range(Meas_rang(0))
            If (inst_error <> 0) Then
                Show_Inst_Error(inst_error)
                Exit Sub
            End If
        Next

        'Move to start wavelength  with Sweep Start method.
        inst_error = TSL.Sweep_Start
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
        End If

        If Me.chkeach_ch.Checked Then
            'Reference measurement one channel at a time
            inst_error = Each_channel_reference(inst_flag)
        Else
            inst_error = All_channel_reference(inst_flag)
        End If

        If inst_error <> 0 Then
            If inst_error = -9999 Then
                MsgBox("MPM Trigger receive error! Please check trigger cable connection.", vbOKOnly)
            ElseIf inst_flag = True Then
                Show_Inst_Error(inst_error)             'Instullment error
            Else
                Show_STS_Error(inst_error)              'Processing error
            End If
            Exit Sub
        End If

        inst_error = TSL.Sweep_Stop
        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
        End If

        MsgBox("Completed.", vbOKOnly)

    End Sub
    Private Function All_channel_reference(ByRef inst_flag As Boolean) As Integer

        '------------------------------------------------------------------------------
        '           Get Reference
        '------------------------------------------------------------------------------
        Dim inst_error As Integer                       'Instullment error
        Dim loop1 As Integer
        Dim setting_SOP As PCU.SOP_Stauts               'Setting SOP 


        'SOP Loop
        ' SOP must to set for V -> H-> 45-> RC
        For loop1 = 0 To 3

            Select Case loop1
                Case 0
                    setting_SOP = PCU.SOP_Stauts.LVP   'LVP(0)
                Case 1
                    setting_SOP = PCU.SOP_Stauts.LHP   'LHP(1)
                Case 2
                    setting_SOP = PCU.SOP_Stauts.LP45  'LP45(2)
                Case 3
                    setting_SOP = PCU.SOP_Stauts.RCP   'RCP(3)
            End Select

            'Setting SOP 
            inst_error = PCU.Set_SOP_Stauts(setting_SOP)

            If (inst_error <> 0) Then
                inst_flag = True
                Return inst_error
            End If

            'Sweep 
            inst_error = Sweep_Process()

            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error

            End If






            'Move to start wavelength  with Sweep Start method.
            inst_error = TSL.Sweep_Start
            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If


            'get logging data & add in STSProcess class

            inst_error = Get_reference_samplingdata(inst_flag, setting_SOP)

            If inst_error <> 0 Then



                Return inst_error


            End If
        Next


        '------Reference data rescaling 
        Dim process_error As Integer
        process_error = Cal_STS.Cal_RefData_Rescaling()

        If process_error <> 0 Then
            inst_flag = False
            Return process_error

        End If

        Return 0

    End Function

    Private Function Each_channel_reference(ByRef inst_flag As Boolean) As Integer

        '------------------------------------------------------------------------------
        '           Get Reference
        '------------------------------------------------------------------------------
        Dim inst_error As Integer                       'Instullment error
        Dim setting_SOP As PCU.SOP_Stauts               'Setting SOP 


        For Each item As STSDataStruct In Refdata_struct

            ' SOP must to set for V -> H-> 45-> RC
            Select Case item.SOP
                Case 0
                    MsgBox("Connect fiber to MPM" & item.MPMNumber + 1 & "_Slot" & item.SlotNumber & "_Ch" & item.ChannelNumber & ".", vbOKOnly)
                    setting_SOP = PCU.SOP_Stauts.LVP   'LVP(0)
                Case 1
                    setting_SOP = PCU.SOP_Stauts.LHP   'LHP(1)
                Case 2
                    setting_SOP = PCU.SOP_Stauts.LP45  'LP45(2)
                Case 3
                    setting_SOP = PCU.SOP_Stauts.RCP   'RCP(3)
            End Select

            'Setting SOP 
            inst_error = PCU.Set_SOP_Stauts(setting_SOP)

            If (inst_error <> 0) Then
                inst_flag = True
                Return inst_error
            End If

            'Sweep 
            inst_error = Sweep_Process()

            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If


            'Move to start wavelength  with Sweep Start method.
            inst_error = TSL.Sweep_Start
            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If


            'get logging data & add in STSProcess class
            inst_error = Get_Each_channel_reference_samplingdata(inst_flag, item.MPMNumber, item.SlotNumber, item.ChannelNumber, setting_SOP, item.SweepCount)

            If inst_error <> 0 Then
                Return inst_error
            End If

            '------Reference data rescaling 
            Dim process_error As Integer
            process_error = Cal_STS.Cal_RefData_Rescaling()

            If process_error <> 0 Then
                inst_flag = False
                Return process_error
            End If

        Next

        Return 0

    End Function

    Private Function Get_Each_channel_reference_samplingdata(ByRef inst_flag As Boolean, ByVal currentMPMNumber As Integer, ByVal currentSlotNumber As Integer, ByVal currentChannelNumber As Integer, ByVal currentSOP As PCU.SOP_Stauts, ByVal currentSweepCount As Integer) As Integer
        '---------------------------------------------------------------
        '       Get logging reference data & add in 
        '---------------------------------------------------------------
        Dim inst_error As Integer                        ' Instullment error
        Dim logg_data() As Single = Nothing              'MPM Logging data
        Dim cal_error As Integer                         'process error


        '----Load　Reference MPM data & add  in data for STS Process Class for each channel
        For Each item As STSDataStruct In Refdata_struct

            If (item.MPMNumber <> currentMPMNumber Or item.SlotNumber <> currentSlotNumber Or item.ChannelNumber <> currentChannelNumber Or item.SOP <> currentSOP) Then
                Continue For
            End If

            ' Read corresponded  MPM channel data
            inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, logg_data)

            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If

            'Add in to MPM reference data to STS Process Class
            cal_error = Cal_STS.Add_Ref_MPMData_CH(logg_data, item)

            If cal_error <> 0 Then
                inst_flag = False
                Return cal_error
            End If
        Next

        '----Load　Reference Monitor data 
        Dim triggerdata() As Single = Nothing
        Dim monitordata() As Single = Nothing

        inst_error = SPU.Get_Sampling_Rawdata(triggerdata, monitordata)

        If inst_error <> 0 Then
            inst_flag = True
            Return inst_error
        End If

        '-- Add reference monitor data associated with parameters of the same SOP
        For Each monitor_item As STSDataStruct In Ref_monitordata_struct
            If (monitor_item.SlotNumber = currentSlotNumber And monitor_item.ChannelNumber = currentChannelNumber And monitor_item.SOP = currentSOP And monitor_item.SweepCount = currentSweepCount) Then
                cal_error = Cal_STS.Add_Ref_MonitorData(triggerdata, monitordata, monitor_item)

                If cal_error <> 0 Then
                    inst_flag = False
                    Return cal_error
                End If

                Exit For
            End If
        Next


        Return 0


    End Function

    Private Function Get_reference_samplingdata(ByRef inst_flag As Boolean, ByVal currentSOP As PCU.SOP_Stauts) As Integer
        '---------------------------------------------------------------
        '       Get logging reference data & add in 
        '---------------------------------------------------------------
        Dim inst_error As Integer                        ' Instullment error
        Dim logg_data() As Single = Nothing              'MPM Logging data
        Dim cal_error As Integer                         'process error


        '----Load　Reference MPM data & add  in data for STS Process Class for each channel
        For Each item As STSDataStruct In Refdata_struct

            If (item.SOP <> currentSOP) Then
                Continue For
            End If

            ' Read corresponded  MPM channel data
            inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, logg_data)

            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If

            'Add in to MPM reference data to STS Process Class
            cal_error = Cal_STS.Add_Ref_MPMData_CH(logg_data, item)

            If cal_error <> 0 Then
                inst_flag = False
                Return cal_error
            End If
        Next

        '----Load　Reference Monitor data 
        Dim triggerdata() As Single = Nothing
        Dim monitordata() As Single = Nothing

        inst_error = SPU.Get_Sampling_Rawdata(triggerdata, monitordata)

        If inst_error <> 0 Then
            inst_flag = True
            Return inst_error
        End If

        '-- Add reference monitor data associated with parameters of the same SOP
        For Each monitor_item As STSDataStruct In Ref_monitordata_struct
            If monitor_item.SOP = currentSOP Then
                cal_error = Cal_STS.Add_Ref_MonitorData(triggerdata, monitordata, monitor_item)

                If cal_error <> 0 Then
                    inst_flag = False
                    Return cal_error
                End If

                Exit For
            End If
        Next


        Return 0


    End Function
    Private Function Get_measurement_samplingdata(ByVal sweepcount As Integer, ByVal currentSOP As PCU.SOP_Stauts, ByRef inst_flag As Boolean) As Integer
        '---------------------------------------------------------------
        '       Get logging measurement data & add in 
        '---------------------------------------------------------------
        Dim inst_error As Integer                        ' Instullment error
        Dim logg_data() As Single = Nothing              'MPM Logging data
        Dim cal_error As Integer                         'process error


        '----Load　measurement MPM data & add  in data for STS Process Class for each channel
        For Each item As STSDataStruct In Data_struct

            If (item.SweepCount <> sweepcount) Or (item.SOP <> currentSOP) Then
                Continue For
            End If

            'Load corresponded MPM channel data
            inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, logg_data)

            If inst_error <> 0 Then
                inst_flag = True
                Return inst_error
            End If

            'Add in to MPM reference data to STS Process Class
            cal_error = Cal_STS.Add_Meas_MPMData_CH(logg_data, item)

            If cal_error <> 0 Then
                inst_flag = False
                Return cal_error
            End If

        Next

        'Load monitor data
        Dim triggerdata() As Single = Nothing               'trigger timming data
        Dim monitordata() As Single = Nothing               'monitor data
        inst_error = SPU.Get_Sampling_Rawdata(triggerdata, monitordata)

        If inst_error <> 0 Then
            inst_flag = True
            Return inst_error
        End If

        '-- Add measurement monitor data associated with parameters of the same SOP & sweep count
        For Each monitor_item As STSMonitorStruct In Meas_monitordata_struct

            If (monitor_item.SweepCount = sweepcount) And (monitor_item.SOP = currentSOP) Then
                cal_error = Cal_STS.Add_Meas_MonitorData(triggerdata, monitordata, monitor_item)

                If cal_error <> 0 Then
                    inst_flag = False
                    Return cal_error
                End If
                Exit For
            End If
        Next


        Return 0


    End Function
    Private Function Get_MPM_Loggdata(ByVal deveice As Integer, ByVal slot As Integer, ByVal ch As Integer, ByRef data() As Single)
        '---------------------------------------------------------------
        '       Get MPM Logg data
        '--------------------------------------------------------------
        Dim inst_error As Integer

        inst_error = MPM(deveice).Get_Each_Channel_Logdata(slot, ch, data)
        Return inst_error

    End Function

    Private Function Sweep_Process() As Integer
        '------------------------------------------------------------
        '       Sweep Process
        '------------------------------------------------------------
        Dim inst_error As Integer               'Instullment error
        Dim loop1 As Integer                    'loop count 



        'MPM sampling start 
        For loop1 = 0 To UBound(MPM)
            inst_error = MPM(loop1).Logging_Start
            If inst_error <> 0 Then
                Return inst_error
            End If
        Next


        'TSL waiting for start status 
        inst_error = TSL.Waiting_For_Sweep_Status(2000, TSL.Sweep_Status.WaitingforTrigger)

        If inst_error <> 0 Then
            '----error handling -> MPM Logging Stop
            For loop1 = 0 To UBound(MPM)
                MPM(loop1).Logging_Stop()
            Next

            Return inst_error
        End If


        'SPU sampling start
        inst_error = SPU.Sampling_Start()

        If inst_error <> 0 Then
            '----error handling -> MPM Logging Stop
            For loop1 = 0 To UBound(MPM)
                MPM(loop1).Logging_Stop()
            Next

            Return inst_error
        End If

        'TSL issue software trigger
        inst_error = TSL.Set_Software_Trigger()

        If inst_error <> 0 Then
            '----error handling -> MPM Logging Stop
            For loop1 = 0 To UBound(MPM)
                MPM(loop1).Logging_Stop()
            Next
            Return inst_error
        End If


        'SPU waiting for sampling 
        inst_error = SPU.Waiting_for_sampling()

        If inst_error <> 0 Then
            '----error handling -> MPM Logging Stop
            For loop1 = 0 To UBound(MPM)
                MPM(loop1).Logging_Stop()
            Next
            Return inst_error
        End If


        Dim mpm_stauts As Integer
        Dim mpm_count As Integer
        Dim timeout As Double = 2000                  'MPM Logging Status timeout(2000msec) after the SPU sampling completed.
        Dim st As New Stopwatch
        Dim mpm_complet_flag As Boolean = True

        st.Start()                                    'timer start for mpm logging status timeout.   

        'MPM waiting for sampling 
        Do
            For loop1 = 0 To UBound(MPM)
                inst_error = MPM(loop1).Get_Logging_Status(mpm_stauts, mpm_count)
                If inst_error <> 0 Then
                    Return inst_error
                End If

                If mpm_stauts = 1 Then
                    Exit Do
                End If
            Next

            If st.ElapsedMilliseconds >= timeout Then
                mpm_complet_flag = False
                Exit Do
            End If
        Loop


        ' MPM sampling stop
        For loop1 = 0 To UBound(MPM)
            inst_error = MPM(loop1).Logging_Stop()
            If inst_error <> 0 Then
                Return inst_error
            End If
        Next

        'TSL Waiting for standby
        inst_error = TSL.Waiting_For_Sweep_Status(5000, TSL.Sweep_Status.Standby)

        If inst_error <> 0 Then
            Return inst_error
        End If


        If mpm_complet_flag = False Then
            Return -9999
        End If


        Return 0

    End Function

    Private Sub btnmeas_Click(sender As Object, e As EventArgs) Handles btnmeas.Click
        '-------------------------------------------------------------------------
        '           Mesurement Process
        '-------------------------------------------------------------------------
        Dim loop1 As Integer                        'loop Count 
        Dim loop2 As Integer                        'loop count2     
        Dim inst_error As Integer                   'instllment error   
        Dim inst_flag As Boolean                    'instrment error flag
        Dim soploop As Integer                      'SOP loop count 
        Dim setSOP As PCU.SOP_Stauts                'setting SOP
        Dim sweepcounter As Integer                 'Sweep counter 

        Cal_STS.Clear_Measdata()

        'Move to start wavelength  with Sweep Start method.
        inst_error = TSL.Sweep_Start()

        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
        End If

        '---------Measurement-------------------------------------
        'Rang Loop
        For loop1 = 0 To Meas_rang.Count - 1

            'MPM range Setting 
            For loop2 = 0 To UBound(MPM)

                inst_error = MPM(loop2).Set_Range(Meas_rang(loop1))

                If inst_error <> 0 Then
                    Show_Inst_Error(inst_error)
                    Exit Sub
                End If
            Next


            'Lower range & if checked "2SOP for low power range"
            If Me.chk2scan.Checked = True And loop1 <> 0 Then
                soploop = 2
            Else
                soploop = 4
            End If

            'SOP loop
            For loop2 = 0 To soploop - 1

                Select Case loop2
                    Case 0
                        setSOP = PCU.SOP_Stauts.LVP
                    Case 1
                        setSOP = PCU.SOP_Stauts.LHP
                    Case 2
                        setSOP = PCU.SOP_Stauts.LP45
                    Case 3
                        setSOP = PCU.SOP_Stauts.RCP
                End Select

                'SOP Setting 
                inst_error = PCU.Set_SOP_Stauts(setSOP)
                If inst_error <> 0 Then
                    Show_Inst_Error(inst_error)
                    Exit Sub
                End If

                ' Sweep process
                inst_error = Sweep_Process()
                If inst_error <> 0 And inst_error <> -9999 Then
                    Show_Inst_Error(inst_error)
                    Exit Sub
                End If

                If inst_error = -9999 Then
                    MsgBox("MPM Trigger receive error! Please check trigger cable connection.", vbOKOnly)
                    Exit Sub
                End If

                'TSL Next　SweepStart
                inst_error = TSL.Sweep_Start()

                If inst_error <> 0 Then
                    Show_Inst_Error(inst_error)
                    Exit Sub
                End If

                ' get loggging data & Add in STS Process class
                inst_error = Get_measurement_samplingdata(sweepcounter + 1, setSOP, inst_flag)

                If inst_error <> 0 Then
                    If inst_flag = True Then
                        Show_Inst_Error(inst_error)
                    Else
                        Show_STS_Error(inst_error)
                    End If

                    Exit Sub
                End If
                sweepcounter = sweepcounter + 1
            Next
        Next

        '---STS data Processing--------------------------------------------- 

        Dim process_error As Integer                        'STS　Process error

        'Rescaling
        process_error = Cal_STS.Cal_MeasData_Rescaling()

        If process_error <> 0 Then
            Show_STS_Error(process_error)
            Exit Sub
        End If

        Dim merge_type As Module_Type
        If Flag_215 = True Then
            merge_type = Module_Type.MPM_215
        ElseIf Flag_213 = True Then
            merge_type = Module_Type.MPM_213
        Else
            merge_type = Module_Type.MPM_211
        End If

        'Process ranges merge
        process_error = Cal_STS.Cal_IL_Merge(merge_type)

        'TSL Sweep Stop
        inst_error = TSL.Sweep_Stop()

        '-----PDL Calcurete process-------------------------------------------
        process_error = PDL_Process_AndSave()


        MsgBox("Completed.", vbOKOnly)

    End Sub
    Private Function PDL_Process_AndSave() As Integer
        '-----------------------------------------------------
        '       STS PDL Process
        '-----------------------------------------------------
        Dim wavetable() As Double = Nothing                  'Target　Wavelength table
        Dim inst_error As Integer                            'instrument error
        Dim correctionSOP(,,) As Single = Nothing            'Correnction SOP data for wavelength  (wavelengthindex,SOP,Sop vector position)
        Dim cal_error As Integer                             'Process class error



        '----------------------------------------------------------------------------
        '   1. Get target wavelength table from Process class
        '   2. pass wavelength table & recive calcureted correction SOP array(3D)
        '   3. pass correction SOP array for Prosecc class
        '   4. Get processed IL data from Prosecc class
        '   5. Calculate PDL & IL & ILmax & ILmin from 4.data 
        '--------------------------------------------------------------------------
        '1
        cal_error = Cal_STS.Get_Target_Wavelength_Table(wavetable)
        If cal_error <> 0 Then
            Show_STS_Error(cal_error)
            Return cal_error
        End If

        '2
        System.Windows.Forms.Application.DoEvents()
        inst_error = PCU.Cal_All_SOP_Parametar(wavetable, correctionSOP)

        If inst_error <> 0 Then
            Show_Inst_Error(inst_error)
            Return cal_error
        End If


        '3 
        cal_error = Cal_STS.Add_PCU_CalData(correctionSOP)
        If cal_error <> 0 Then
            Show_STS_Error(cal_error)
            Return cal_error
        End If

        '4 
        Dim loop1 As Integer
        Dim loop2 As Integer
        Dim loop3 As Integer
        Dim ildata() As Single = Nothing                        'merged IL data
        Dim get_struct As STSDataStructForMerge                 'struct of get
        Dim befor_struct As STSDataStructForMerge               'befor struct
        'Dim items As STSDataStruct               'befor struct

        Dim SOPIL(,) As Single = Nothing                        '4SOP IL data
        Dim calPDL() As Single = Nothing                        'calculated PDL
        Dim calIL() As Single = Nothing                         'calculated IL
        Dim calILmax() As Single = Nothing                      'calculated IL Max
        Dim calILmin() As Single = Nothing                      'calculated IL Min
        Dim fpath As String = String.Empty                      'file path
        Dim writer As System.IO.StreamWriter                    'writer
        Dim writestr As String = String.Empty                   'write string 


        ReDim SOPIL(3, wavetable.Length - 1)

        For Each item As STSDataStructForMerge In Mergedata_struct
            If (item.MPMNumber = befor_struct.MPMNumber) _
                And (item.SlotNumber = befor_struct.SlotNumber) _
                And (item.ChannelNumber = befor_struct.ChannelNumber) Then
                Continue For
            End If
            'SOP　loop
            For loop1 = 0 To 3
                get_struct.MPMNumber = item.MPMNumber
                get_struct.SlotNumber = item.SlotNumber
                get_struct.ChannelNumber = item.ChannelNumber
                get_struct.SOP = loop1

                cal_error = Cal_STS.Get_IL_Merge_Data(ildata, get_struct)

                If cal_error <> 0 Then
                    Show_STS_Error(cal_error)
                    Return cal_error
                End If

                '1Ddata ->2D data array
                For loop2 = 0 To UBound(ildata)
                    SOPIL(loop1, loop2) = ildata(loop2)
                Next
            Next

            befor_struct = get_struct

            ' 5.Calcurate of PDL 
            cal_error = Cal_STS.Cal_PDL(SOPIL, calPDL, calIL, calILmax, calILmin)

            If cal_error <> 0 Then
                Show_STS_Error(cal_error)
                Return cal_error
            End If


            ''--------Save data for each ch---------------------------------
            Me.SaveFileDialog1.Title = "Device" & CStr(get_struct.MPMNumber + 1) & "Slot" & CStr(get_struct.SlotNumber) & "Ch" & CStr(get_struct.ChannelNumber) & "PDL data save path"
            Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
            Me.SaveFileDialog1.ShowDialog()

            fpath = Me.SaveFileDialog1.FileName
            writer = New System.IO.StreamWriter(fpath, False, System.Text.Encoding.GetEncoding("UTF-8"))
            'hedder

            writestr = "Wavelength(nm),IL(dB),PDL(dB),ILMax(dB),ILMin(dB)"

            writer.WriteLine(writestr)

            For loop3 = 0 To UBound(wavetable)

                writestr = CStr(wavetable(loop3)) & "," & CStr(calIL(loop3)) & "," & CStr(calPDL(loop3)) & "," & CStr(calILmax(loop3)) & "," & CStr(calILmin(loop3))
                writer.WriteLine(writestr)
            Next

            writer.Close()

            '-----Save Mueller data ??--------------------------------------

            If chksavemu.Checked = True Then
                Dim m11() As Double = Nothing
                Dim m12() As Double = Nothing
                Dim m13() As Double = Nothing
                Dim m14() As Double = Nothing


                '------------------------------------------
                '      m11 = (H+V)/2
                '      m12 = (H-V)/2
                '      m13 = 45-m11
                '      m14 = RC-m11
                '-------------------------------------------
                'Load mueller parameter
                cal_error = Cal_STS.Get_Mueller_Raw_Data(m11, m12, m13, m14)

                If cal_error <> 0 Then
                    Show_STS_Error(cal_error)
                    Return cal_error
                End If

                'file save
                Me.SaveFileDialog1.Title = "Device" & CStr(get_struct.MPMNumber) & "Slot" & CStr(get_struct.SlotNumber) & "Ch" & CStr(get_struct.ChannelNumber) & "Mueller data save path"
                Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
                Me.SaveFileDialog1.ShowDialog()

                fpath = Me.SaveFileDialog1.FileName

                writer = New System.IO.StreamWriter(fpath, False, System.Text.Encoding.GetEncoding("UTF-8"))
                'hedder

                writestr = "Wavelength(nm),m11(mW),m12(mW),m13(mW),m14(mW)"

                writer.WriteLine(writestr)

                For loop3 = 0 To UBound(wavetable)

                    writestr = CStr(wavetable(loop3)) & "," & CStr(m11(loop3)) & "," & CStr(m12(loop3)) & "," & CStr(m13(loop3)) & "," & CStr(m14(loop3))
                    writer.WriteLine(writestr)
                Next

                writer.Close()

            End If

        Next

        Return 0

    End Function
    Private Function Save_Measurement_data() As Integer
        '-------------------------------------------------------
        '       Save Measurement data
        '-------------------------------------------------------
        Dim wavelength_table() As Double = Nothing            'Rescaled wavelength table  
        Dim lstILdata As New List(Of Single())               'IL data list 
        Dim process_error As Integer                          'process class error  
        Dim loop1 As Integer                                  'loop count
        Dim ildata() As Single = Nothing                      'il data arrray

        'Get Rescaled wavelength tabel 
        process_error = Cal_STS.Get_Target_Wavelength_Table(wavelength_table)


        'Get IL data 
        If Flag_215 = True Then
            For Each items As STSDataStruct In Data_struct

                process_error = Cal_STS.Get_IL_Data(ildata, items)
                If process_error <> 0 Then
                    Return process_error
                End If

                lstILdata.Add(ildata.ToArray)
            Next

        Else

            For Each items As STSDataStructForMerge In Mergedata_struct

                process_error = Cal_STS.Get_IL_Merge_Data(ildata, items)
                If process_error <> 0 Then
                    Return process_error
                End If

                lstILdata.Add(ildata.ToArray)
            Next


        End If


        '-----Data Save 
        Dim file_path As String = String.Empty

        Me.SaveFileDialog1.Title = "IL data save"
        Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
        Me.SaveFileDialog1.ShowDialog()

        file_path = Me.SaveFileDialog1.FileName

        Dim writer As New System.IO.StreamWriter(file_path, False, System.Text.Encoding.GetEncoding("UTF-8"))
        Dim write_string As String = Nothing

        Dim loop2 As Integer

        For loop1 = 0 To UBound(wavelength_table)

            write_string = wavelength_table(loop1)

            For loop2 = 0 To lstILdata.Count - 1
                write_string = write_string & "," & lstILdata(loop2)(loop1)
            Next

            writer.WriteLine(write_string)

        Next

        writer.Close()

        Return 0

    End Function

    Private Sub btnsaveref_rawdata_Click(sender As Object, e As EventArgs) Handles btnsaveref_rawdata.Click
        '---------------------------------------------------------------------------
        '           Save reference Raw data
        '---------------------------------------------------------------------------
        Dim loop1 As Integer                        'loop count1   
        Dim loop2 As Integer                        'loop count2
        Dim loop3 As Integer                        'loop count3
        Dim process_error As Integer                'process class error
        Dim wavetable() As Double = Nothing         'wavelength table
        Dim powdata() As Single = Nothing           'powerdata  rescaled    
        Dim monitordata() As Single = Nothing       'monitordata rescaled 
        Dim lstpowdata As New List(Of Single())     'Power data list
        Dim lstmonitordata As New List(Of Single()) 'monitor data list 


        '---- Get reference Raw data (after the rescaling)

        'Get Target wavelengt table
        process_error = Cal_STS.Get_Target_Wavelength_Table(wavetable)

        If process_error <> 0 Then
            Show_STS_Error(process_error)
            Exit Sub
        End If

        '-------Load Each SOP data & Save
        Dim fpath As String = String.Empty                  'file path 
        Dim hedder As String = String.Empty                 'file hedder 
        Dim write_str As String = String.Empty              'write string 
        Dim sop_string As String = String.Empty             'SOP String 

        Dim writer As System.IO.StreamWriter

        'Save each SOP reference data files.
        For loop1 = 0 To 3
            hedder = ""
            lstpowdata = New List(Of Single())
            lstmonitordata = New List(Of Single())

            Select Case loop1
                Case 0
                    sop_string = "Vartical"
                Case 1
                    sop_string = "Horizontal"
                Case 2
                    sop_string = "45°Linear"
                Case 3
                    sop_string = "Right-handed circle"
            End Select

            Me.SaveFileDialog1.Title = "Reference Raw data" & sop_string
            Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
            Me.SaveFileDialog1.ShowDialog()
            fpath = Me.SaveFileDialog1.FileName

            writer = New System.IO.StreamWriter(fpath, False, System.Text.Encoding.GetEncoding("UTF-8"))

            hedder = "Wavelength(nm)"

            'Load matched SOP raw data form Processing class
            '--for power data & hedder 
            For Each item As STSDataStruct In Refdata_struct
                If item.SOP <> loop1 Then
                    Continue For
                End If
                process_error = Cal_STS.Get_Ref_Power_Rawdata(item, powdata)
                If process_error <> 0 Then
                    Show_STS_Error(process_error)
                    Exit Sub
                End If

                lstpowdata.Add(powdata.ToArray)

                hedder = hedder & ",MPM" & CStr(item.MPMNumber + 1) & "Slot" & CStr(item.SlotNumber) & "Ch" & CStr(item.ChannelNumber)
            Next

            If Me.chkeach_ch.Checked Then
                For Each item As STSDataStruct In Refdata_struct
                    If item.SOP <> loop1 Then
                        Continue For
                    End If
                    hedder = hedder & ",Monitor_MPM" & CStr(item.MPMNumber + 1) & "Slot" & CStr(item.SlotNumber) & "Ch" & CStr(item.ChannelNumber)
                Next
            Else
                hedder = hedder & ",Monitor"
            End If


            writer.WriteLine(hedder)
            '--for monitor data

            Dim get_struct As STSDataStruct                 'struct of get
            Dim befor_struct As New STSDataStruct           'befor struct

            For Each item As STSDataStruct In Ref_monitordata_struct

                If Me.chkeach_ch.Checked Then
                    If (item.MPMNumber = befor_struct.MPMNumber) _
                        And (item.SlotNumber = befor_struct.SlotNumber) _
                        And (item.ChannelNumber = befor_struct.ChannelNumber) _
                        Or item.SOP <> loop1 Then
                        Continue For
                    End If
                Else
                    If item.SOP <> loop1 Then
                        Continue For
                    End If
                End If

                process_error = Cal_STS.Get_Ref_Monitor_Rawdata(item, monitordata)

                If process_error <> 0 Then
                    Show_STS_Error(process_error)
                    Exit Sub
                End If
                get_struct.MPMNumber = item.MPMNumber
                get_struct.SlotNumber = item.SlotNumber
                get_struct.ChannelNumber = item.ChannelNumber
                get_struct.SOP = item.SOP

                lstmonitordata.Add(monitordata.ToArray)
                befor_struct = get_struct

            Next

            'data write 
            For loop2 = 0 To UBound(wavetable)
                'wavelength data
                write_str = CStr(wavetable(loop2))

                'Power data
                For loop3 = 0 To lstpowdata.Count - 1
                    write_str = write_str & "," & lstpowdata(loop3)(loop2)
                Next

                'monitordata
                For loop4 = 0 To lstmonitordata.Count - 1
                    write_str = write_str & "," & lstmonitordata(loop4)(loop2)
                Next

                writer.WriteLine(write_str)
            Next

            writer.Close()
        Next
        MsgBox("Completed.", vbOKOnly)

    End Sub

    Private Sub btnsaveRawdata_Click(sender As Object, e As EventArgs) Handles btnsaveRawdata.Click
        '-------------------------------------------------------------------------
        '       Save measurement raw data for designated Range
        '-------------------------------------------------------------------------
        Dim loop1 As Integer                                        'loop1
        Dim loop2 As Integer                                        'loop2
        Dim loop3 As Integer                                        'loop3
        Dim wavelength_table() As Double = Nothing                  'Wavelength table
        Dim monitordata() As Single = Nothing                       'monitor data array
        Dim powerdata() As Single = Nothing                         'Power data array
        Dim errorcode As Integer                                    'Errorcode
        Dim lstpower As New List(Of Single())                       'Power list 
        Dim rangenumber As Integer                                  'save range number


        '-- Get Wavelength table
        errorcode = Cal_STS.Get_Target_Wavelength_Table(wavelength_table)

        If errorcode <> 0 Then
            Show_STS_Error(errorcode)      'designated range
            Exit Sub
        End If

        '---check to range number 1st  or not & data exist
        Dim first_rangeflag As Boolean
        Dim exist_flag As Boolean = False

        rangenumber = Me.txtsaverange.Text

        For Each item In Data_struct
            If item.RangeNumber > rangenumber Then
                first_rangeflag = True
            End If
            'exist or not 
            If item.RangeNumber = rangenumber Then
                exist_flag = True
            End If
        Next

        If exist_flag = False Then
            MsgBox("Range data is not exist.", vbOKOnly)
            Exit Sub
        End If


        Dim fpath As String = String.Empty              'File　path
        Dim writer As System.IO.StreamWriter            'Writer 
        Dim write_string As String = String.Empty       'write string
        Dim hedder As String = String.Empty             'hedder 
        Dim sopcount As Integer                         'sopcount 
        Dim sop_string As String = String.Empty         'sop string
        Dim sweepcount As Integer                       'sweepcount

        'low range & 2scan 
        If first_rangeflag = False And Me.chk2scan.Checked = True Then
            sopcount = 1                            '2Scan data
        Else
            sopcount = 3                            '4Scan data
        End If

        '----Save designated range measurement raw data  for each SOP---------------------------
        For loop1 = 0 To sopcount
            hedder = ""
            lstpower = New List(Of Single())

            Select Case loop1
                Case 0
                    sop_string = "Vartical"
                Case 1
                    sop_string = "Horizontal"
                Case 2
                    sop_string = "45°Linear"
                Case 3
                    sop_string = "Right-handed circle"
            End Select

            'check sweep count　→長いから関数化する
            sweepcount = check_sweepcount(rangenumber, loop1)

            Me.SaveFileDialog1.Title = "Save Range" & CStr(rangenumber) & "_" & sop_string & " SOP data"
            Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
            Me.SaveFileDialog1.ShowDialog()

            fpath = Me.SaveFileDialog1.FileName

            writer = New System.IO.StreamWriter(fpath, False, System.Text.Encoding.GetEncoding("UTF-8"))
            hedder = "Wavelength(nm)"


            'sarch for match  data from "STSDataStruct"---------------------------------
            '-for power data
            For Each item As STSDataStruct In Data_struct

                If (item.SOP <> loop1) Or (item.RangeNumber <> rangenumber) Then
                    Continue For
                End If

                'Load measurement raw data
                errorcode = Cal_STS.Get_Meas_Power_Rawdata(item, powerdata)

                If errorcode <> 0 Then
                    Show_STS_Error(errorcode)
                    Exit Sub
                End If

                lstpower.Add(powerdata.ToArray)

                hedder = hedder & "," & "MPM" & CStr(item.MPMNumber + 1) & "Slot" & CStr(item.SlotNumber) & "Ch" & CStr(item.ChannelNumber)

            Next

            hedder = hedder & ",Monitordata"

            writer.WriteLine(hedder)

            ' for monitor data
            For Each item As STSMonitorStruct In Meas_monitordata_struct
                If item.SOP <> loop1 Or item.SweepCount <> sweepcount Then
                    Continue For
                End If

                errorcode = Cal_STS.Get_Meas_Monitor_Rawdata(item, monitordata)

                If errorcode <> 0 Then
                    Show_STS_Error(errorcode)
                    Exit Sub
                End If
            Next
            ' Write data
            For loop2 = 0 To UBound(wavelength_table)
                write_string = CStr(wavelength_table(loop2))

                For loop3 = 0 To lstpower.Count - 1
                    write_string = write_string & "," & lstpower(loop3)(loop2)
                Next

                write_string = write_string & "," & monitordata(loop2)

                writer.WriteLine(write_string)
            Next

            writer.Close()

        Next

        MsgBox("Completed.", vbOKOnly)

    End Sub
    Private Function check_sweepcount(ByVal rangenumber As Integer, ByVal sopcount As Integer) As Integer
        '---------------------------------------------------------------------------
        '       Return Sweep count for range and SOP status
        '----------------------------------------------------------------------------
        Dim loop1 As Integer
        Dim sweepcount As Integer

        For loop1 = 0 To Meas_rang.Count - 1

            If Meas_rang(loop1) = rangenumber Then

                Select Case loop1
                    Case 0
                        '1st range
                        sweepcount = sopcount + 1
                        Return sweepcount
                    Case 1
                        '2nd rangge
                        sweepcount = 4 + sopcount + 1
                        Return sweepcount
                    Case 2
                        '3rd range
                        If Me.chk2scan.Checked = True Then
                            sweepcount = 6 + sopcount + 1
                        Else
                            sweepcount = 8 + sopcount + 1
                        End If
                        Return sweepcount

                    Case 3
                        '4th range
                        If Me.chk2scan.Checked = True Then
                            sweepcount = 8 + sopcount + 1
                        Else
                            sweepcount = 12 + sopcount + 1
                        End If
                        Return sweepcount

                    Case 4
                        '5th range
                        If Me.chk2scan.Checked = True Then
                            sweepcount = 10 + sopcount + 1
                        Else
                            sweepcount = 16 + sopcount + 1
                        End If

                        Return sopcount

                End Select
            End If
        Next
        ' falut
        Return 0

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '-----------------------------------------------------------------------------
        '       Reference Data Read
        '       This function must use after "SET" 
        '-----------------------------------------------------------------------------
        Dim fpath As String = String.Empty                  'filepath
        Dim reader As System.IO.StreamReader                'data reader    
        Dim sop_loop As Integer                             'SOP loop
        Dim sop_str As String = String.Empty                'SOP String 

        '-------Reference file　Read 
        For sop_loop = 0 To 3
            Select Case sop_loop
                Case 0
                    sop_str = "Vartical"
                Case 1
                    sop_str = "Horizontal"
                Case 2
                    sop_str = "45°Linear"
                Case 3
                    sop_str = "Right-handed circle"
            End Select

            Me.OpenFileDialog1.Title = sop_str & " Reference Data"
            Me.OpenFileDialog1.ShowDialog()
            fpath = Me.OpenFileDialog1.FileName

            reader = New System.IO.StreamReader(fpath)

            Dim read_st As String = String.Empty                            'Read String 
            Dim split_st() As String = Nothing                              'split strin array

            'hedder Read 
            read_st = reader.ReadLine
            read_st = read_st.Trim()
            split_st = Split(read_st, ",")


            Dim ch_count As Integer                                         'file data ch count
            Dim loop1 As Integer                                            'Loop count1
            Dim chk_str As String = String.Empty                            'check string
            Dim mpm_number As Integer                                       'MPM number
            Dim slot_number As Integer                                      'Slot number
            Dim ch_number As Integer                                        'ch number 
            If Me.chkeach_ch.Checked Then
                ch_count = (split_st.Count - 1) / 2
            Else
                ch_count = split_st.Count - 2
            End If

            'Check data cout 
            If ch_count <> Me.chklst_ch.CheckedItems.Count Then

                MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                reader.Close()
                Exit Sub
            End If

            '-----Check parameter & make reference data struct 
            Dim refdata_strunct As STSDataStruct                        'Data struct for reference
            Dim lst_refdata_struct As New List(Of STSDataStruct)        'Data struct for reference List    
            Dim match_flag As Boolean = False                           'match flag

            For loop1 = 1 To ch_count
                'MPM device number 
                chk_str = split_st(loop1).Substring(3, 1)
                mpm_number = CInt(chk_str) - 1

                'MPM Slot number 
                chk_str = split_st(loop1).Substring(8, 1)
                slot_number = CInt(chk_str)

                'MPM Ch number 
                chk_str = split_st(loop1).Substring(11, 1)
                ch_number = CInt(chk_str)


                ' Check exsist data in data struct 
                For Each item As STSDataStruct In Refdata_struct

                    If item.MPMNumber = mpm_number And item.SlotNumber = slot_number And item.ChannelNumber = ch_number And item.SOP = sop_loop Then
                        match_flag = True
                        Exit For
                    End If
                Next

                If match_flag = False Then
                    MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                    reader.Close()
                    Exit Sub
                End If

                'Add reference data struct 
                refdata_strunct.MPMNumber = mpm_number
                refdata_strunct.SlotNumber = slot_number
                refdata_strunct.ChannelNumber = ch_number
                refdata_strunct.RangeNumber = 1
                refdata_strunct.SweepCount = sop_loop + 1
                refdata_strunct.SOP = sop_loop

                lst_refdata_struct.Add(refdata_strunct)

            Next

            '-------Read Reference data form .csv file
            If Me.chkeach_ch.Checked Then

                Dim power() As List(Of Single)                 'Power data list
                Dim monitor() As List(Of Single)               'Monitordata
                Dim counter As Integer                         'Counter
                Dim wavelength As Double                       'Read Wavelength 

                ReDim power(ch_count - 1)
                ReDim monitor(ch_count - 1)

                For loop1 = 0 To ch_count - 1
                    power(loop1) = New List(Of Single)
                    monitor(loop1) = New List(Of Single)
                Next

                Do
                    read_st = reader.ReadLine()

                    If read_st = "" Then
                        Exit Do
                    End If

                    read_st = read_st.Trim()
                    split_st = Split(read_st, ",")

                    'Check Start Wavelength 
                    If counter = 0 Then
                        If CDbl(split_st(0)) <> Me.txtstartwave.Text Then
                            MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                            reader.Close()
                            Exit Sub
                        End If
                    End If

                    'hold wavelength data
                    wavelength = CDbl(split_st(0))

                    For loop1 = 0 To ch_count - 1
                        power(loop1).Add(CDbl(split_st(loop1 + 1)))
                    Next

                    For loop1 = 0 To ch_count - 1
                        monitor(loop1).Add(CDbl(split_st(ch_count + loop1 + 1)))
                    Next

                    counter = counter + 1

                Loop

                reader.Close()

                'Check Stop wavelength 
                If wavelength <> CStr(Me.txtstopwave.Text) Then
                    MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                    Exit Sub
                End If

                'check number of point 

                Dim datapoint As Integer                            'number of data point 

                datapoint = (Math.Abs(Me.txtstopwave.Text - Me.txtstartwave.Text) / Me.txtstepwave.Text) + 1

                If datapoint <> monitor(0).Count Then
                    MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                    Exit Sub
                End If

                '-------Add in  data to STS Process class
                Dim errorcode As Integer                            'Errorcode
                counter = 0

                For Each item In lst_refdata_struct
                    'Add in reference data of rescaled.
                    errorcode = Cal_STS.Add_Ref_Rawdata(power(counter).ToArray, monitor(counter).ToArray, item)

                    If errorcode <> 0 Then
                        Show_Inst_Error(errorcode)
                        Exit Sub
                    End If
                    counter = counter + 1
                Next
            Else
                Dim power() As List(Of Single)                 'Power data list 
                Dim monitor As New List(Of Single)             'Monitordata
                Dim counter As Integer                         'Counter
                Dim wavelength As Double                       'Read Wavelength 

                ReDim power(ch_count - 1)

                For loop1 = 0 To ch_count - 1
                    power(loop1) = New List(Of Single)
                Next

                Do
                    read_st = reader.ReadLine()

                    If read_st = "" Then
                        Exit Do
                    End If

                    read_st = read_st.Trim()
                    split_st = Split(read_st, ",")

                    'Check Start Wavelength 
                    If counter = 0 Then
                        If CDbl(split_st(0)) <> Me.txtstartwave.Text Then
                            MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                            reader.Close()
                            Exit Sub
                        End If
                    End If

                    'hold wavelength data
                    wavelength = CDbl(split_st(0))

                    For loop1 = 0 To ch_count - 1
                        power(loop1).Add(CDbl(split_st(loop1 + 1)))
                    Next

                    monitor.Add(CDbl(split_st(ch_count + 1)))

                    counter = counter + 1
                Loop

                reader.Close()

                'Check Stop wavelength 
                If wavelength <> CStr(Me.txtstopwave.Text) Then
                    MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                    Exit Sub
                End If

                'check number of point 
                Dim datapoint As Integer                            'number of data point 

                datapoint = (Math.Abs(Me.txtstopwave.Text - Me.txtstartwave.Text) / Me.txtstepwave.Text) + 1

                If datapoint <> monitor.Count Then
                    MsgBox("Reference data mismatch.Please selecet right data.", vbOKOnly)
                    Exit Sub
                End If
                '-------Add in  data to STS Process class
                Dim errorcode As Integer                            'Errorcode
                counter = 0

                For Each item In lst_refdata_struct
                    'Add in reference data of rescaled.
                    errorcode = Cal_STS.Add_Ref_Rawdata(power(counter).ToArray, monitor.ToArray, item)

                    If errorcode <> 0 Then
                        Show_Inst_Error(errorcode)
                        Exit Sub
                    End If
                    counter = counter + 1
                Next

            End If

        Next


        MsgBox("Completed.", vbOKOnly)


    End Sub

    Private Sub btnsavecalil_Click(sender As Object, e As EventArgs) Handles btnsavecalil.Click
        '------------------------------------------------------------------------------
        '     Save Calculated IL (Cancel for SOP wavelength dependence)
        '          This method must be run after the PDL Calculation
        '------------------------------------------------------------------------------
        Dim fpath As String = String.Empty
        Dim wavelengthdata() As Double = Nothing
        Dim cal_IL(,) As Single = Nothing
        Dim errorcode As Integer


        'Load Wavelength data 
        errorcode = Cal_STS.Get_Target_Wavelength_Table(wavelengthdata)

        If errorcode <> 0 Then
            Show_STS_Error(errorcode)
            Exit Sub
        End If


        'Get Calculated IL
        errorcode = Cal_STS.Get_Calibrated_IL(cal_IL)

        If errorcode <> 0 Then
            Show_STS_Error(errorcode)
            Exit Sub
        End If


        'Data save
        Me.SaveFileDialog1.Title = "Save to Calculated IL"
        Me.SaveFileDialog1.Filter = "csv file(*.csv)|*.csv"
        Me.SaveFileDialog1.ShowDialog()

        fpath = Me.SaveFileDialog1.FileName

        Dim writer As New System.IO.StreamWriter(fpath, False, System.Text.Encoding.GetEncoding("UTF-8"))               'writer 
        Dim loop1 As Integer
        Dim loop2 As Integer
        Dim write_string As String = String.Empty


        'hedder
        write_string = "Wavelength(nm),IL_V(dB),IL_H(dB),IL_45(dB),IL_RCP(dB)"

        writer.WriteLine(write_string)


        For loop1 = 0 To UBound(wavelengthdata)

            write_string = wavelengthdata(loop1) & ","

            For loop2 = 0 To 3
                write_string = write_string & CStr(cal_IL(loop2, loop1)) & ","
            Next

            writer.WriteLine(write_string)

        Next
        writer.Close()

        MsgBox("Completed.")
    End Sub
End Class
