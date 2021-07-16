using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.Models;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    // поскольку много разных правил шашек, то я выбрал правила, которые больше понравились,  а именно - обычная шашка назад ходить и бить не может. Дамка может все, но становится дамкой со следующего хода 
    public partial class MainWindow : Window
    {
        const int MAP_SIZE = 8;
        // белая шашка / игрок с белыми шашками
        const int WHITE = 1;
        // черная шашка / игрок с черными шашками
        const int BLACK = 2;
        // клетка, на которой нет ни черной ни белой шашки
        const int EMPTY_CELL = 0;
        // ридонли поля также будем именовать в апперкейсе что бы в тексте они воспринимались как константы для повышения читабельности
        // стандартный цвет клеток, по которым будут ходить шашки - "черные клетки доски"
        readonly Brush STANDART_CELL_COLOR = Brushes.SaddleBrown;
        readonly Brush WHITE_CELL_COLOR = Brushes.White;
        readonly Brush SELECTED_CHECKER_COLOR = Brushes.DeepSkyBlue;
        readonly Brush POSSIBLE_STEP_COLOR = Brushes.YellowGreen;
        readonly Brush KILL_STEP_COLOR = Brushes.Red;

        int[,] map;
        List<Cell> cells = new List<Cell>();

        int currentPlayer = WHITE;     
        bool isMooving = false;
        bool oneMoreVictim = false;
        bool isSecondCheck = false;

        Cell prevCell = null;

        string blackQueen = System.IO.Path.GetFullPath(@"..\..\Images\black-checker-Queen.png");
        string whiteQueen = System.IO.Path.GetFullPath(@"..\..\Images\white-checker-Queen.png");
 

        public MainWindow()
        {
            InitializeComponent();
            FieldInit();           
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void FieldInit()
        {
            // вспомогательный массив. вместе с тем как будет меняться обстановка на поле, так же будет и меняться обстановка здесь
            map = new int[MAP_SIZE, MAP_SIZE]
            {
                {  0  , WHITE,   0,   WHITE,   0,   WHITE,   0,   WHITE,},

                {WHITE,   0,   WHITE,   0,   WHITE,   0,   WHITE,   0,  },

                {  0  , WHITE,   0,   WHITE,   0,   WHITE,   0,   WHITE,},

                {  0,     0,     0,     0,     0,     0,     0,     0,  },

                {  0,     0,     0,     0,     0,     0,     0,     0,  },

                {BLACK,   0,   BLACK,   0,   BLACK,   0,   BLACK,   0,  },

                 {  0  , BLACK,   0,   BLACK,  0,   BLACK,   0,   BLACK,},

                {BLACK,   0,   BLACK,   0,   BLACK,   0,   BLACK,   0,  },
            };

            CreateMap();
        }
        private void CreateMap()
        {
            string blackChecker = System.IO.Path.GetFullPath(@"..\..\Images\black-checker.png");
            string whiteChecker = System.IO.Path.GetFullPath(@"..\..\Images\white-checker.png");

            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    Cell cell = new Cell
                    {
                        Row = i,
                        Column = j,
                        Background = ((i + j) % 2 == 0) ? WHITE_CELL_COLOR : STANDART_CELL_COLOR,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        EnemyCell = null,
                        IsQueen = false
                    };

                    if(map[i, j] == WHITE)
                    {
                        cell.Content = new Image { Source = new BitmapImage(new Uri(whiteChecker)) };
                    }
                    else if(map[i, j] == BLACK)
                    {
                        cell.Content = new Image { Source = new BitmapImage(new Uri(blackChecker)) };
                    }
                   
                    cell.MouseDown += Cell_MouseDown;

                    cells.Add(cell);
                    grid.Children.Add(cell);    
                    Grid.SetRow(cell, cell.Row);
                    Grid.SetColumn(cell, cell.Column);
                } 
            }
        }


        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnblockAllCells();
            Cell selectedCell = sender as Cell;
            if (isMooving && selectedCell.Background == KILL_STEP_COLOR)
            {
                // убиваем шашку
                // убираем картинку
                selectedCell.EnemyCell.Content = null;
                // убираем с поля (в вспомогательном массиве)
                map[selectedCell.EnemyCell.Row, selectedCell.EnemyCell.Column] = EMPTY_CELL;


                if (IsGameOver())
                {
                    ResetGame();
                    return;
                }


                // очищаем другие возможные варианты жертв
                foreach (var cell in cells)
                {
                    if (cell.Background == KILL_STEP_COLOR)
                    {
                        cell.EnemyCell = null;
                    }
                }
 
                if (prevCell.IsQueen)
                {
                    selectedCell.IsQueen = true;
                    prevCell.IsQueen = false;
                }

                isSecondCheck = true;
            }


            ResetAllCellsColor();

            
            // если нажали не на пустую клетку и нажали на доступные шашки для текущего игрока (первые ходят белые, по этому в первый раз можем нажать только на белую)
            if (map[selectedCell.Row, selectedCell.Column] != EMPTY_CELL &&
                map[selectedCell.Row, selectedCell.Column] == currentPlayer)
            {
                selectedCell.Background = SELECTED_CHECKER_COLOR;
                isMooving = true;
                SetColorPossibleCellSteps(selectedCell);
                BlockAllCells();
                UnblockActiveCells();
            }
            else
            {
                // если не шашка текущего игрока и уже была выбранна шашка перед этим
                if (isMooving)
                {                   
                    if (prevCell.IsQueen)
                    {
                        selectedCell.IsQueen = true;
                        prevCell.IsQueen = false;
                    }

                    // меняем местами клетки (в вспомогательном массиве)
                    int tmp = map[selectedCell.Row, selectedCell.Column];
                    map[selectedCell.Row, selectedCell.Column] = map[prevCell.Row, prevCell.Column];
                    map[prevCell.Row, prevCell.Column] = tmp;

                    // обновляеем картинку
                    selectedCell.Content = prevCell.Content;
                    prevCell.Content = null;

                    
                    UnblockAllCells();


                    // если стала дамкой
                    if(selectedCell.Row == 0 && currentPlayer == BLACK)                        
                    {
                        selectedCell.Content = new Image { Source = new BitmapImage(new Uri(blackQueen)) };
                        selectedCell.IsQueen = true;
                    }
                    if(selectedCell.Row == MAP_SIZE - 1 && currentPlayer == WHITE)
                    {
                        selectedCell.Content = new Image { Source = new BitmapImage(new Uri(whiteQueen)) };
                        selectedCell.IsQueen = true;
                    }


                    // если это вторая проверка после убийства одной шашки
                    if (isSecondCheck)
                    {
                        // теперь подстветим только красным клетки, если есть возможные жертвы
                        SetColorPossibleCellSteps(selectedCell);
                    }
                    // если их нет, ничего не происходит, ничего не подсвечивается и передаем ход другому игроку
                    if (oneMoreVictim != true)
                    {
                        ChangePlayer();
                        isMooving = false;
                    }
                    else
                    {
                        BlockAllCellsExceptKill();
                    }
                    isSecondCheck = false;
                    oneMoreVictim = false;
                }
            }
            prevCell = selectedCell;
        }     

        private void SetColorPossibleCellSteps(Cell selectedCell)
        {
            if (!selectedCell.IsQueen)
            {
                #region Обычная шашка
                // белый игрок - шашки сверху
                if (currentPlayer == WHITE)
                {
                    // проверяем клетку слева внизу
                    if (IsInsideMapBorders(selectedCell.Row + 1, selectedCell.Column - 1))
                    {
                        Cell possibleStep = GetCell(selectedCell.Row + 1, selectedCell.Column - 1);
                        if (map[possibleStep.Row, possibleStep.Column] == EMPTY_CELL)
                        {
                            // если это не вторая проверка, во второй нужно подствечивать только красные клетки
                            if (!isSecondCheck)
                            {
                                // можно ходить                       
                                possibleStep.Background = POSSIBLE_STEP_COLOR;
                            }
                        }
                        else if (map[possibleStep.Row, possibleStep.Column] == BLACK)
                        {
                            if (IsInsideMapBorders(possibleStep.Row + 1, possibleStep.Column - 1))
                            {
                                if (map[possibleStep.Row + 1, possibleStep.Column - 1] == EMPTY_CELL)
                                {
                                    // можно бить
                                    Cell beatStep = GetCell(possibleStep.Row + 1, possibleStep.Column - 1);
                                    beatStep.Background = KILL_STEP_COLOR;
                                    // будем хранить в этой клетке потенциально возможную жертву, на случай, если ее нужно будет убить 
                                    beatStep.EnemyCell = possibleStep;
                                    if (isSecondCheck)
                                    {
                                        oneMoreVictim = true;
                                    }
                                }
                            }
                        }
                    }
                    // проверяем клетку справа внизу
                    if (IsInsideMapBorders(selectedCell.Row + 1, selectedCell.Column + 1))
                    {
                        Cell possibleStep = GetCell(selectedCell.Row + 1, selectedCell.Column + 1);
                        if (map[possibleStep.Row, possibleStep.Column] == EMPTY_CELL)
                        {
                            if (!isSecondCheck)
                            {
                                // можно ходить                       
                                possibleStep.Background = POSSIBLE_STEP_COLOR;
                            }
                        }
                        else if (map[possibleStep.Row, possibleStep.Column] == BLACK)
                        {
                            if (IsInsideMapBorders(possibleStep.Row + 1, possibleStep.Column + 1))
                            {
                                if (map[possibleStep.Row + 1, possibleStep.Column + 1] == EMPTY_CELL)
                                {
                                    // можно бить
                                    Cell beatStep = GetCell(possibleStep.Row + 1, possibleStep.Column + 1);
                                    beatStep.Background = KILL_STEP_COLOR;
                                    beatStep.EnemyCell = possibleStep;
                                    if (isSecondCheck)
                                    {
                                        oneMoreVictim = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else // черный игрок - шашки снизу
                {
                    // проверяем клетку слева вверху
                    if (IsInsideMapBorders(selectedCell.Row - 1, selectedCell.Column - 1))
                    {
                        Cell possibleStep = GetCell(selectedCell.Row - 1, selectedCell.Column - 1);
                        if (map[possibleStep.Row, possibleStep.Column] == EMPTY_CELL)
                        {
                            if (!isSecondCheck)
                            {
                                // можно ходить                       
                                possibleStep.Background = POSSIBLE_STEP_COLOR;
                            }
                        }
                        else if (map[possibleStep.Row, possibleStep.Column] == WHITE)
                        {
                            if (IsInsideMapBorders(possibleStep.Row - 1, possibleStep.Column - 1))
                            {
                                if (map[possibleStep.Row - 1, possibleStep.Column - 1] == EMPTY_CELL)
                                {
                                    // можно бить
                                    Cell beatStep = GetCell(possibleStep.Row - 1, possibleStep.Column - 1);
                                    beatStep.Background = KILL_STEP_COLOR;
                                    beatStep.EnemyCell = possibleStep;
                                    if (isSecondCheck)
                                    {
                                        oneMoreVictim = true;
                                    }
                                }
                            }
                        }
                    }
                    // проверяем клетку справа вверху
                    if (IsInsideMapBorders(selectedCell.Row - 1, selectedCell.Column + 1))
                    {
                        Cell possibleStep = GetCell(selectedCell.Row - 1, selectedCell.Column + 1);
                        if (map[possibleStep.Row, possibleStep.Column] == EMPTY_CELL)
                        {
                            if (!isSecondCheck)
                            {
                                // можно ходить                       
                                possibleStep.Background = POSSIBLE_STEP_COLOR;
                            }
                        }
                        else if (map[possibleStep.Row, possibleStep.Column] == WHITE)
                        {
                            if (IsInsideMapBorders(possibleStep.Row - 1, possibleStep.Column + 1))
                            {
                                if (map[possibleStep.Row - 1, possibleStep.Column + 1] == EMPTY_CELL)
                                {
                                    // можно бить
                                    Cell beatStep = GetCell(possibleStep.Row - 1, possibleStep.Column + 1);
                                    beatStep.Background = KILL_STEP_COLOR;
                                    beatStep.EnemyCell = possibleStep;
                                    if (isSecondCheck)
                                    {
                                        oneMoreVictim = true;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else // дамка
            {
                // даже если методы очень похожи, для повышения читабельности сделаем их все же отдельными 4-мя методами
                LeftBottomDirectionCheck(selectedCell);
                RightBottomDirectionCheck(selectedCell);
                LeftTopDirectionCheck(selectedCell);
                RightTopDirectionCheck(selectedCell);
            }
        }

        #region Проверка ходов дамки
        private void RightTopDirectionCheck(Cell selectedCell)
        {
            int row = selectedCell.Row;
            int column = selectedCell.Column;
            int match = 0;
            while (row != 0 && column != MAP_SIZE - 1)
            {
                row--;
                column++;
                if (map[row, column] == EMPTY_CELL)
                {                   
                    Cell cell = GetCell(row, column);
                    if (!isSecondCheck)
                    {
                        // можно ходить
                        cell.Background = POSSIBLE_STEP_COLOR;
                    }                   
                }
                else if (map[row, column] == currentPlayer)
                {
                    break;
                }
                else // враг
                {
                    match = 1;
                    break;
                }
            }
            if (match == 1)
            {
                if (IsInsideMapBorders(row - 1, column + 1))
                {
                    Cell cell = GetCell(row - 1, column + 1);
                    if (map[cell.Row, cell.Column] == EMPTY_CELL)
                    {
                        // можно бить
                        cell.Background = KILL_STEP_COLOR;
                        Cell enemy = GetCell(row, column);
                        cell.EnemyCell = enemy;
                        if (isSecondCheck)
                        {
                            oneMoreVictim = true;
                        }
                    }
                }
            }
        }

        private void LeftTopDirectionCheck(Cell selectedCell)
        {
            int row = selectedCell.Row;
            int column = selectedCell.Column;
            int match = 0;
            while (row != 0 && column != 0)
            {
                row--;
                column--;
                if (map[row, column] == EMPTY_CELL)
                {
                    Cell cell = GetCell(row, column);
                    if (!isSecondCheck)
                    {
                        // можно ходить
                        cell.Background = POSSIBLE_STEP_COLOR;
                    }
                }
                else if (map[row, column] == currentPlayer)
                {
                    break;
                }
                else // враг
                {
                    match = 1;
                    break;
                }
            }
            if (match == 1)
            {
                if (IsInsideMapBorders(row - 1, column - 1))
                {
                    Cell cell = GetCell(row - 1, column - 1);
                    if (map[cell.Row, cell.Column] == EMPTY_CELL)
                    {
                        // можно бить
                        cell.Background = KILL_STEP_COLOR;
                        Cell enemy = GetCell(row, column);
                        cell.EnemyCell = enemy;
                        if (isSecondCheck)
                        {
                            oneMoreVictim = true;
                        }
                    }
                }
            }
        }

        private void RightBottomDirectionCheck(Cell selectedCell)
        {
            int row = selectedCell.Row;
            int column = selectedCell.Column;
            int match = 0;
            while (row != MAP_SIZE - 1 && column != MAP_SIZE - 1)
            {
                row++;
                column++;
                if (map[row, column] == EMPTY_CELL)
                {
                    Cell cell = GetCell(row, column);
                    if (!isSecondCheck)
                    {
                        // можно ходить
                        cell.Background = POSSIBLE_STEP_COLOR;
                    }
                }
                else if (map[row, column] == currentPlayer)
                {
                    break;
                }
                else // враг
                {
                    match = 1;
                    break;
                }
            }
            if (match == 1)
            {
                if (IsInsideMapBorders(row + 1, column + 1))
                {
                    Cell cell = GetCell(row + 1, column + 1);
                    if (map[cell.Row, cell.Column] == EMPTY_CELL)
                    {
                        // можно бить
                        cell.Background = KILL_STEP_COLOR;
                        Cell enemy = GetCell(row, column);
                        cell.EnemyCell = enemy;
                        if (isSecondCheck)
                        {
                            oneMoreVictim = true;
                        }
                    }
                }
            }
        }

        private void LeftBottomDirectionCheck(Cell selectedCell)
        {
            int row = selectedCell.Row;
            int column = selectedCell.Column;
            int match = 0;
            while (row != MAP_SIZE - 1 && column != 0)
            {
                row++;
                column--;
                if (map[row, column] == EMPTY_CELL)
                {
                    Cell cell = GetCell(row, column);
                    if (!isSecondCheck)
                    {
                        // можно ходить
                        cell.Background = POSSIBLE_STEP_COLOR;
                    }
                }
                else if (map[row, column] == currentPlayer)
                {
                    break;
                }
                else // враг
                {
                    match = 1;
                    break;
                }
            }
            if (match == 1)
            {
                if (IsInsideMapBorders(row + 1, column - 1))
                {
                    Cell cell = GetCell(row + 1, column - 1);
                    if (map[cell.Row, cell.Column] == EMPTY_CELL)
                    {
                        // можно бить
                        cell.Background = KILL_STEP_COLOR;
                        Cell enemy = GetCell(row, column);
                        cell.EnemyCell = enemy;
                        if (isSecondCheck)
                        {
                            oneMoreVictim = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region Вспомогательные методы
        private void BlockAllCellsExceptKill()
        {
            foreach (var cell in cells)
            {
                if (cell.Background != KILL_STEP_COLOR)
                {
                    cell.IsEnabled = false;
                }
            }
        }
        private void ChangePlayer()
        {
            currentPlayer = currentPlayer == WHITE ? BLACK : WHITE;
        }
        private void ResetAllCellsColor()
        {
            // воспользуемся той же формулой, как при установке бекграунда клетки во время инициализации, только вместо i + j будем складывать уже координаиы каждой   клетки
            foreach (var cell in cells)
            {
                cell.Background = ((cell.Row + cell.Column) % 2 == 0) ? WHITE_CELL_COLOR : STANDART_CELL_COLOR;
            }
        }
        private void BlockAllCells()
        {
            foreach (var cell in cells)
            {
                cell.IsEnabled = false;
            }
        }
        private void UnblockAllCells()
        {
            foreach (var cell in cells)
            {
                cell.IsEnabled = true;
            }
        }
        public bool IsInsideMapBorders(int row, int col)
        {
            if (row >= MAP_SIZE || col >= MAP_SIZE || row < 0 || col < 0)
            {
                return false;
            }
            return true;
        }
        private Cell GetCell(int row, int column)
        {
            return cells.Find(c => c.Row == row && c.Column == column);
        }
        private void UnblockActiveCells()
        {
            foreach (var cell in cells)
            {
                if (map[cell.Row, cell.Column] == currentPlayer)
                {
                    cell.IsEnabled = true;
                }
                if (cell.Background == POSSIBLE_STEP_COLOR)
                {
                    cell.IsEnabled = true;
                }
                if (cell.Background == KILL_STEP_COLOR)
                {
                    cell.IsEnabled = true;
                }
            }
        }
        private void ResetGame()
        {
            grid.Children.Clear();
            cells.Clear();
            map = null;
            isMooving = false;
            oneMoreVictim = false;
            isSecondCheck = false;
            prevCell = null;
            currentPlayer = WHITE;
            FieldInit();
        }
        private bool IsGameOver()
        {
            int white = 0;
            int black = 0;
            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    if (map[i, j] == WHITE)
                    {
                        white = 1;
                    }
                    if (map[i, j] == BLACK)
                    {
                        black = 1;
                    }
                }
            }
            if (white == 0 || black == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
