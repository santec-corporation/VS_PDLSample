
// ILSTS_Sample_MFC.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CILSTS_Sample_MFCApp: 
// �йش����ʵ�֣������ ILSTS_Sample_MFC.cpp
//

class CPDLSTS_Sample_MFCApp : public CWinApp
{
public:
	CPDLSTS_Sample_MFCApp();

// ��д
public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern CPDLSTS_Sample_MFCApp theApp;