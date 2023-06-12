
// PDLSTS_Sample_MFCDlg.h : 头文件
//

#pragma once
#include "afxwin.h"


// CPDLSTS_Sample_MFCDlg 对话框
class CPDLSTS_Sample_MFCDlg : public CDialogEx
{
	// 构造
public:
	CPDLSTS_Sample_MFCDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_PDLSTS_SAMPLE_MFC_DIALOG };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();

	DECLARE_MESSAGE_MAP()
public:
	CCheckListBox m_listbox;
	char* CPDLSTS_Sample_MFCDlg::SPU_Resource; // SPU resource name 
	char* CPDLSTS_Sample_MFCDlg::USB_Resource; // USB resource name 
	CComboBox DAQ_LIST;
	CString CPDLSTS_Sample_MFCDlg::TSL_Communicater;               // TSL Communicator name
	CString CPDLSTS_Sample_MFCDlg::MPM_Communicater;               // MPM Communicator name
	CString CPDLSTS_Sample_MFCDlg::PCU_Communicater;               // PCU Communicator name

	CString TSL_Address;                    // TSL address
	int TSL_Portnumber;                // TSL LAN port number
	CString PCU_Address;                    // PCU address
	int PCU_Portnumber;                // PCU LAN port number

	int MPM_Count;                     // MPM number of device 
	CString MPM_Address[2];                 // MPM address 
    int MPM_Portnumber[2];             // MPM LAN port number
	bool PCU_useing_internal_DAQ;
	CString SPU_DeviveID;                   // SPU Deviece resource

	afx_msg void OnBnClickedbtnconnect();
	afx_msg void OnBnClickedrdo570();
//	afx_msg void OnBnClickedgpib();
	afx_msg void OnBnClickedtsltcpip();
	afx_msg void OnBnClickedtslusb();
	afx_msg void OnBnClickeddev();
	afx_msg void OnBnClickedmpmgpib();
	afx_msg void OnBnClickedrdo550();
	afx_msg void OnBnClickedmpmtcpip();
	CComboBox PCU_USB_LIST;
	CComboBox USB_LIST;
	afx_msg void OnBnClickedrdopcu100();
	afx_msg void OnClickedRdotslGpib();
	afx_msg void OnClickedRdopcuGpib();
	afx_msg void OnBnClickedrdopcu110();
	afx_msg void OnBnClickedrdopcu_lan();
	afx_msg void OnBnClickedrdopcu_usb();
};
