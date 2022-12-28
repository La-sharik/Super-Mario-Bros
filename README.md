# Долгосрочное домашнее задание (игра "Марио")

## Этап I
Время на этап: **18 часов**

### Цель

Необходимо разработать игру для одного пользователя против компьютера. Правила для различных вариантов игры можно найти в интернете (например, в Википедии) и ниже в ТЗ.

### Задание

На этом этапе необходимо реализовать desktop-приложение c графической отрисовкой процесса и реализацией основной логики игры.

#### Функционал, который должен быть реализован:
1. Игровое меню
    * кнопка **Начать** - открывает новое окно с настройками игры:
        * выбор **уровня(1-1 - 1-3 и 2-1 - 2-3)**
        * кнопка "Начать игру"
    * кнопка **Выход** - закрывает игру.
2. Игровой процесс
    * отрисовка юнитов, текстур и прептствий на экране, создание физики и правил(ограничений) игры, передвижения юнитов
    * удаление юнита после смерти (реализация одного из правил игры)
    * реализация изменений юнита "Марио"
    * реализация алгоритма поведения бота-противника (вражеских юнитов)
    * реализация алгоритма определения конца игры
    * реализация досрочного окончания игры (в случае смерти "Марио")
    * возможность поставить игру на паузу с отображением **диалогового окна**:
        * кнопка **Возобновить игру**
        * кнопка **Выйти из игры** - возврат в основное меню программы
        * кнопка **Рестарт** - запуск уровня заново
    * визуальная часть:
        * отображение **времени** игры
        * отображение **счёта** игры
        * отображение **уровня**
        * отображение **количества жизней**
    * по завершении игры вывод **диалогового окна**:
        * **игра пройдена**
    * логика игры:
        * **Базовые правила для всех вариантов игры:**
            - "Марио" появляется в левом краю уровня.
            - "Марио" умеет бегать влево и вправо и прыгать.
            - Для прохождения уровня необходимо довести "Марио" до флага у правого края карты.
            - Для прохождения игры необходимо пройти все уровни.
            - Изначально у "Марио" 3 жизни, но походу игры можно собрать бонусный красный гриб, увеличивающий модельку "Марио" и дарующий возможность пережить столкновение с одним любым вражеским юнитом и бонусный зелёный гриб увеличивающий количество жизней на одну.
            - Существуют три типа вражеских юнитов: черепаха, злой гриб.
            - Если наступить на черепаху, на её месте остоётся панцырь. Если на него наступить, то он полетит в сторону, сбивая всех вражеских юнитов.
            - Черепаху и злой гриб можно убить прыгнув сверху или сбить панцырем, за это игрок получает 200 очков.
            - Смертью для "Марио" является падение вниз, касание с боку черепахи или злого гриба.
            - Если у вас кончатся жизни игра закончатся и открывается диалоговое окно.
            - "Марио" умеет выбивать награды из бонусного ящика с помощью прыжка.
            - Бонусы из бонусного ящика: звёздочка, монетка, грибы.
            - Если игрок потерял свойство гриба, он сможет съесть ещё.
            - Монетки увеличивают счёт игрока на 200 и могут появиться при уничтожении крпичей или бонусных блоков.
            - Грибы и звёздочки увеличивают счёт игрока на 1000 и могут появиться при уничтожении бонусных блоков.
            - Чем быстрее игрок пройдёт уровень, те больше он получит бонусных очков за время.
            - Если игрок не укладывается в 200 секунд, то он проиграл.
3. Конфигурация игры
    * все важные настройки игры хранить в файлах в любом удобном формате

### Командная разработка

Далее пошагово представлен **пример** процесса реализации игры на этапе I. Каждый из членов команды выбирает себе задание,
согласовав этот шаг разработки с остальными участниками команды. Шаги разработки составлены так, что **лучше всего** для команды — полностью закрыть все задачи **конкретного** шага, прежде чем переходить к **следующему** шагу (тут вам потребуется командная работа).

На каждом шаге разработки ожидается **очевидный** промежуточный результат от команды. Команда должна иметь возможность отчитаться в любой момент о состоянии дел по разработке игры. Основное ТЗ можно посмотреть ещё раз
[тут](#функционал-который-должен-быть-реализован), подробное ТЗ будет расписано в каждом шаге.

#### Шаги разработки:

1. Время на работу: **6 часов**  

   * **Разработка макета визуальной части процесса игры и части главного меню**.  

     Необходимо разработать подробный макет (в любом из доступных средств визуализации макетов) основного экрана игры.
     На экране должны быть:
     * **время игры**
     * **счёт игры**
     * **количество жизней**
     * **счётчик уровня**
     * сама **карта**, по которой будут передвигаться юниты (которые, разумеется, также необходимо отобразить). Очевидно, что всё это должно лаконично смотреться и не "накладываться" друг на друга.

     Для каждой отдельной кнопки меню необходимо сделать "подсвечивание" кнопки.

   * **Разработка основного меню игры**.  

     Необходимо разработать основное меню игры с кнопками: **Начать**, **Выбор уровня** и **Выход** с указанным ранее функционалом.        

   Для этого шага разработки **результатом** является готовое меню с фоном. Каждая кнопка должна открывать своё окно, а все прописываемые в окнах параметры должны записываться в соответствующие поля конфигурационного файла или переменные программы, если их нет смысла хранить в файле.

2. Время на работу: **6 часов**  

   * **Визуализация окна игры**  

     На этом шаге необходимо отобразить на экран всё то, что было нанесено на макет на предыдущем шаге. На экране могут быть "заглушки". Главное, чтобы был реализован такой функционал, который позволит другому члену команды использовать прописанные игроками параметры (имена, цвета и т.д.), чтобы связать визуализацию с логикой.  

   * **Привязка визуальной составляющей к логике игры**  

     Необходимо написать функционал, который позволяет получать параметры, вводимые игроками на предыдущем шаге, чтобы использовать их для визуализации на экране и для реализации логики игры. Здесь необходимо параллельное взаимодействие двух членов команды, чтобы по итогу полученные на предыдущем шаге параметры  игроков корректно отображались на экране игры.  

   * **Написание логики передвижения юнитов игрока и бота для одного из вариантов игры**

     Необходимо написать функционал, который отображает на экране юнитов игрока и бота и позволяет им двигаться в соответствии с правилами. Необходимо написать функционал, позволяющий управлять юнитом игрока на карте. Также требуется учесть свойство гриба и его изменения модельки юнита игрока.

   Для этого шага разработки **результатом** является основное окно игры с отображенными параметрами на экране: время игры, счет, номер уровня, количество жизней; карта с юнитами игрока и бота на ней.
   Также должна быть реализована логика передвижения юнитов игрока и бота с возможностью управления.

3. Время на работу: **6 часов**

   * **Реализация поведения бота**

     Необходимо реализовать механику движения злого гриба: ходить из стороны в сторону. Ограничения: стена или любой другой блок.

     Необходимо реализовать механику движения черепахи: ходить из стороны в сторону. Ограничения: стена или любой другой блок, пропасть.

   * **Реализация диалогового окна паузы**  

     Необходимо реализовать диалоговое окно, которое будет появляться при нажатии клавиши "ESC". В диалоговом окне необходимо отобразить информацию и кнопки, представленные ранее в ТЗ.

   * **Реализация диалогового окна по завершении игры**  

     Необходимо написать диалоговое окно, которое вызывается в случае завершения игры или раунда.

   Для этого шага разработки **результатом** является реализованная логика передвижения юнитов игроков для всех уровней игры, а также вывод всех сопутствующих **работающих** диалоговых окон в случае завершения игры или паузы (нажатие на клавишу "ESC"). При этом, должно работать  изменение счётчика уровней, жизней, времени и счёта. На этом шаге игра должна выглядеть готовой для комфортной игры.


## Этап II
Время на этап: **18 часов**

### Цель

Необходимо разработать многопользовательскую (на 2 игрока) версию игры.

В этот этап необходимо включить:
* Выбор уровня - 2-1 или 2-3 при начале игры

Функционал и задачи определить самостоятельно аналогично первому этапу. Второй этап — это развитие первого этапа в многопользовательском режиме.
