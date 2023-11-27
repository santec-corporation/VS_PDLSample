<p align="right"> <a href="https://www.santec.com/en/" target="_blank" rel="noreferrer"> <img src="https://www.santec.com/dcms_media/image/common_logo01.png" alt="santec" 
  width="250" height="45"/> </a> </p>
  
# VS_PDLSample
  Polarization Related Loss test software developed using C#, C++ and VB.net on Visual Studio platform.
  
## List of content

  - ### Overview of Project
    This is an example software of a scan test system for PDL measurements.
      
  - ### System Requirements
    + Development environment  Visual Studio 2015
    +	Windows Framework        4.0 or later
    +	Instrument DLL           2.5.1
    +	STSProcess.DLL           2.2.2
    +	NI DLL                   15.5 or later

- ### Tech Stack
  <p align="left"> <a href="https://isocpp.org/" target="_blank" rel="noreferrer"> <img src="https://isocpp.org/assets/images/cpp_logo.png" alt="cpp" 
  width="50" height="50"/> </a> </p> 
  <p align="left"> <a href="https://dotnet.microsoft.com/en-us/languages/csharp" target="_blank" rel="noreferrer"> <img src="https://th.bing.com/th/id/OIP.1C3f4vlPHd2AU3xuVL3OEQAAAA?w=228&h=256&rs=1&pid=ImgDetMain" alt="cs" 
  width="50" height="50"/> </a> </p> 
  <p align="left"> <a href="https://visualstudio.microsoft.com/vs/features/net-development/" target="_blank" rel="noreferrer"> <img src="https://th.bing.com/th/id/OIP.0-pGgiUq08VxtxFYUQZElgHaEb?w=400&h=239&rs=1&pid=ImgDetMain" alt="vb.net" 
  width="70" height="40"/> </a> </p> 
  <p align="left"> <a href="https://visualstudio.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://th.bing.com/th/id/OIP.I9TwwZg3mQbfGOk7sGJTiwHaHa?w=550&h=550&rs=1&pid=ImgDetMain" alt="visualstudio" 
  width="70" height="40"/> </a> </p> 
  
- ### Configuration
  - Tunable laser TSL Series (TSL-550/TSL-710/TSL-570/TSL-770)
  - Power meter MPM Series (MPM-210/210H/211/212/213/215)   
  - Polarization controller PCU series(PCU-100/PCU-110)
 
  ***Note: This sample software allows you to control up to two MPM main frames (MPM-210 or MPM-210H).***

- ### 3. Connection setting
  - ### Tunable laser (TSL)control
    - TSL-550/710: GPIB
    - TSL-570/TSL-770: GPIB, TCP/IP or USB
       
    ***Note: It can be changed on the source code, but the initial value is the delimiter CRLF specification.***
    
  - ### Power meter (MPM) control
    - MPM-210/210H: GPIB, TCP/IP or USB

  - ### Polarization Controller (PCU) control
    - PCU-100: GPIB 
    - PCU-110: GPIB, TCP/IP or USB

  - ### Line of reference
    #### Use BNC cables to connect the following sections. When using the:
    #### PCU-110
      - TSL - *** Trigger Output	->	MPM - *** Trigger Input
      - PCU-110 Power Monitor	->	MPM - *** Power Monitor <br/> <br/>
      ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/a5f5c99a-11cc-44b6-8f12-56e2e3ba67a8)
      ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/d5cc8e12-63e5-4d01-9a93-f4baa0c4f916)

   #### If it's a PCU-100
     - TSL - ***Trigger Output ->  PCU-100 Trigger Input
     - PCU-100 Trigger Output ->  MPM - ***Trigger Input <br/> <br/>
     ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/b4276de4-0512-4955-9c2e-aed42e5b8ed5)
     ![image](https://github.com/santec-corporation/VS_PDLSample/assets/132535077/8177cb72-5abd-4125-9af1-006165323063)

## 4. Operational steps
  Refer to the operational manual to run the script,
  [ English Manual ](https://github.com/santec-corporation/VS_PDLSample/blob/main/Santec%20PDL%20Swept%20Test%20System%20Manual%20V1.3_EN_20231009.pdf)

## For more information on Swept Test System [CLICK HERE](https://inst.santec.com/products/componenttesting/sts)
