# Задача: реализация учебного распределённого приложения на технологии WCF .net.

Требование 1: использовать внедрение зависимостей и IoC контейнер (Microsoft Unity).
Требование 2: использовать чистые Data контракты (property only).
Требование 3: data access с Entity Framework.
Требование 4: называть проект и сборки так: Фамилия.ИмяПроекта....
Требование 5: в WCF использовать: net.tcp binding, ws-http binding, net.msmq binding.
Требование 6: Клиентское приложение работает с сервером приложений по HTTP, а сервер приложений с сервером данных по tcp и msmq.
Требование 7: Передавать контекст пользователя через заголовки WCF (только идентификатор сессии).
Требование 8: есть 2 роли пользователей: админ и обычный пользователь. Админ может ддобавлять счётчики. Админом является пользователь с Id=1. Он должен быть в бд.

Бизнес цель: Ввод показаний счётчиков квартирантов.
Описание: Пользователь должен вводить показания счётчиков в систему.

Основные действия:
                * Регаем пользователя
                * Логинимся (создаётся сессия)
                * Вносим показания или смотрим уже внесённые
                * Выходим
                

Нужно получить: 3 приложения:
                * Сервер данных (self hosted)
                * Сервер приложения (self hosted)
                * Клиентское приложение (консоль)
                
Сущности: 
                * пользователь (квартирант), 
                * счетчик, 
                * показание счетчика.


Пользователь может добавлять показание для конкретного счетчика и делать выборку по типу и по дате. Регистрация, вход, выход.
Поля - пользователь (имя, пароль) подтверждение в регистрации
счетчик (тип, код, ед. измерения)
показание (код счетчика, значение, дата)


Подзадание 1: сделать всё приложение без использования WCF, но с использованием внедрения зависмостей (должно конфигурироваться с помощью IoC)
Подзадание 2: добавить WCF


## Архитектура приложения:


###3 уровня
1) Клиентское приложение
1.1) Консольное клиентское приложение
2) Сервер приложений
2.1) Бизнес-логика: 
* AccountManager (Register) - пользователи
* AuthManager (Login/Logout) - аутентификация
* CounterManager (Add/Remove/FindByUserID/Find) - менеджер счётчиков
* MetricsManager (Add/Find/GetStatisticsForMonth) - менеджер показаний
3) Сервер данных
3.1) Приложение доступа к данным, СУБД. Содержит репозитории для сущностей

## Сборки:
### Контракты:
Galanin.CounterMetrics.Contracts.DataAccess - Контракты сервера данных
* IUserRepository (NET.TCP)
                * Create(user)
                * FindById(userId) : UserEntity
                * Find(): UserEntity[]
                * DeleteById(userId)
                
* ICounterRepository (NET.TCP)
                * Create(counter)
                * FindById(counter)
                * FindByUserID(userId) : Counter[]
                * DeleteById(userId)
                
* IMetricsStoreRepository (NET.MSMQ) OneWay Persist()
                * Create(counterMetric)
                
* IMetricsRetrieveRepository (NET.TCP)
                * FindUserMetricsForMonth(userId, monthNumber) : CounterMetric[]
                * Find() : CounterMetric[]
Galanin.CounterMetrics.Contracts.Managers - Контракты сервера приложений (ID пользователя передавать через WCF Headers)
* IAccountManager (Register) HTTP
                * Register(userRegisterData)
* IAuthManager (Login/Logout) HTTP
                * Login(loginData) : LoginResult (Сессии храните в каком-нибудь словаре, где ключ - GUID сессии, а данные, например ID пользователя)
                * Logout()
* ICounterManager (Add/Remove/FindByUserID/Find) HTTP
                * Add(counter)
                * Remove(counter)
                * FindByUserID(userId) : Counter[]
                * Find(filter) : Counter[]
* IMetricsManager (Add/GetStatisticsForMonth) HTTP
                * Add(counterMetrica)
                * GetStatisticsForMonth(monthNumber)
                
Galanin.CounterMetrics.Infrastructure
                * Логгер и общий код
Galanin.CounterMetrics.ClientProxies.DataAccess
Galanin.CounterMetrics.ClientProxies.Managers
Galanin.CounterMetrics.DataAccess
Galanin.CounterMetrics.Managers
Galanin.CounterMetrics.Host.DataAccess
Galanin.CounterMetrics.Host.Managers
Galanin.CounterMetrics.ClientApp
Galanin.CounterMetrics.Collapsed


Технологии:
WCF, Misrocoft Unity IoC, Entity Framework
