# VS_PDLSample
 The VS platform uses polarization related loss test software developed by c#, c++ and VB.net

## 1. Overview of Project
This is an example software of a scan test system for PDL measurements.
  + Development environment  Visual Studio 2015
  +	Windows Framework        4.0 or later
  +	Instrument DLL           2.5.1
  +	STSProcess.DLL           2.2.2
  +	NI DLL                   15.5 or later

## 2. Configuration
1.	Tunable laser TSL Series (TSL-550/TSL-710/TSL-570/TSL-770)
2.	Power meter MPM Series (MPM-210/210H/211/212/213/215)
   This sample software allows you to control up to two MPM main frames (MPM-210 or MPM-210H).
3.	Polarization controller PCU series(PCU-100/PCU-110)

## 3. Connection setting
### Tunable laser (TSL)control
  - TSL-550/710: GPIB
  - TSL-570/TSL-770: GPIB, TCP/IP or USB  
    Note: It can be changed on the source code, but the initial value is the delimiter CRLF specification.
### Power meter (MPM) control
  - MPM-210/210H: GPIB, TCP/IP or USB

### Polarization Controller (PCU) control
  - PCU-100: GPIB 
  - PCU-110: GPIB, TCP/IP or USB

### Line of reference
    Use BNC cables to connect the following sections. When using the:
    PCU-110
  - TSL-*** Trigger Output	->	MPM-*** Trigger Input; 
  - PCU-110 Power Monitor	->	MPM-*** Power Monitor;
  ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/a5f5c99a-11cc-44b6-8f12-56e2e3ba67a8)
  ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/d5cc8e12-63e5-4d01-9a93-f4baa0c4f916)

    If it's a PCU-100
  - TSL-***Trigger Output->  PCU-100 Trigger Input
  - PCU-100 Trigger Output->  MPM-***Trigger Input
  ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/b4276de4-0512-4955-9c2e-aed42e5b8ed5)
  ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/8177cb72-5abd-4125-9af1-006165323063)

## 4. Operational steps
Refere to the Manual [HERE](https://github.com/santec-corporation/VS_PDLSample/blob/main/Santec%20PDL%20Swept%20Test%20System%20Manual%20V1.3_EN_20231009.pdf)
