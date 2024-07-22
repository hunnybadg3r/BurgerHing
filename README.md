![](https://i.imgur.com/2hjsSSm.png)
# BURGER HING?
- BURGER HING은 Kiosk Demo App입니다. 
- C#과 WPF를 활용하여 .NET 8을 기반으로 작성되었습니다.
## 목표
- WPF 학습
- 현대적인 WPF 애플리케이션 구현
	- Microsoft가 제공하는 개발방법론과 라이브러리 사용
		- 무분별한 상용 라이브러리 사용 지양
	- 확장과 유지보수가 용이한 애플리케이션 구조
- Custom Control 활용
	- 확장성과 재사용성 최대화
## 구조
MVVM + Services

![](https://i.imgur.com/1GGnMMY.png)
## 사용된 기술
- Dependency Injection
- Community Toolkit MVVM
	- ObservableObject
	- MVVM source generators (Attributes)
		- ObservableProperty, RelayCommand, INotifyPropertyChanged
	- Messenger
- WPF Custom Control

## 다운로드
### Portable
https://github.com/hunnybadg3r/BurgerHing/releases/download/v1/BurgerHing-portable.zip
### Setup (ClickOnce)
https://github.com/hunnybadg3r/BurgerHing/releases/download/v1/BurgerHing-setup-ClickOnce.zip
