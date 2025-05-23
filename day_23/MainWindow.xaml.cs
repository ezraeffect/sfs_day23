using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * DataGrid
 * - 데이터를 표(테이블) 형태로 표시하고 조작할 수 있는 컨트롤
 * - 행과 열로 구성된 표 형식의 UI
 * 
 * [특징]
 * - 데이터 바인딩
 *  ㄴ ItemsSource 속성을 사용해 컬렉션(ex. List<T>)에 바인딩하면, 해당 컬렉션의 데이터가 자동으로 DataGrid에 표시됨
 * - 컬럼 자동/수동 생성 가능
 * - 정렬/필터/스크롤 등 기본적인 테이블 기능 지원
 * 
 * [When]
 * - 테이블 목록을 표 형식으로 보여줄 때
 * - 테이블 데이터를 수정하거나 삭제할 때
 * 
 * [Attribute]
 * - ItemSource : 보여줄 데이터 목록 - 데이터 바인딩용 컬렉션
 *  ㄴ 빈 행에 데이터를 입력하면 새로운 데이터 항목이 DataGrid의 ItemsSource에 추가됨.
 * - AutoGenerateColumns : 자동으로 컬럼 생성 여부를 선택 가능 [Default: true]
 * - CanUserAddRows : 사용자가 직접 행 추가 가능 여부  [Default: true]
 * - CanUserDeleteRows : 사용자가 직접 행 삭제 가능 여부  [Default: true]
 * - CanUserSortColumns : 컬럼 정렬 허용 여부  [Default: true]
 * - IsReadOnly : DataGrid 전체를 읽기 전용으로 설정  [Default: False]
 * - IsReadOnly(ColumnName) : 특정 컬럼만 읽기 전용 설정
 * 
 * [컬럼 생성 방식]
 * AutoGenerateColumns = true (자동 컬럼 생성)
 * - 바인딩된 객체의 속성을 기반으로 컬럼 자동 생성
 *  ㄴ 개발 시간 크게 단축 가능
 *  ㄴ 자료형에 따라 사용자 정의 컬럼 속성 매핑
 *  ㄴ 열 순서 / 헤더명 / 스타일 제어 어려움
 *  
 * AutoGenerateColumns = false (수동 컬럼 정의)
 * - DataGrid.Colums
 * 
 * [사용자 정의 컬럼 속성 종류]
 * DataGrid.Columns 내부에서 사용
 * - DataGridTextColumn : 일반 텍스트 데이터를 표시하고 편집. Binding 속성으로 데이터 원본의 속성을 지정
 * - DataGridCheckBoxColumn : bool 타입의 데이터를 체크박스로 표시
 * - DataGridComboBoxColumn : 드롭다운 선택 컬럼
 * - DataGridTemplateColumn : 셀의 내용을 원하는 WPF 컨트롤로 구성 가능 (버튼, 이미지 등 삽입 가능 / 가장 유연한 컬럼 타입)
 * 
 * [행 선택 및 데이터 접근 관련 속성]
 * - SelectionMode : 단일/다중 선택 설정 (Single / Extended)
 *  ㄴ Single : 단일 행만 선택 가능
 *  ㄴ Extended : 다중 행 선택 가능
 * - SeletedUnit
 *  ㄴ Cell : 셀 단위로 선택
 *  ㄴ FullRow : 행 전체를 선택 (일반적)
 * - SelectedItem : 현재 선택된 단일 항목으 가져옴 (단일 선택 모드)
 * - SelectedItems : 현재 선택된 모든 항목의 컬렉션을 가져옴 (다중 선택 모드)
 * - SelectedIndex :  현재 선택된 항목의 인덱스 가져옴
 */
namespace day_23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> personInfo;

        public MainWindow()
        {
            InitializeComponent();

            LoadData();
            LoadData2();

            LoadData3();
            singleSelectDataGrid.ItemsSource = personInfo;
            multiSelectedDataGrid.ItemsSource = personInfo;
        }

        private void LoadData()
        {
            List<Person> list = new List<Person>()
            {
                new Person() { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person() { Id = 2, Name = "비비빅", Age = 30, IsActive = false },
                new Person() { Id = 3, Name = "박대철", Age = 24, IsActive = true }
            };

            myDataGrid.ItemsSource = list;
        }

        private void LoadData2()
        {
            List<Person> people = new List<Person>()
            {
                new Person() { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person() { Id = 2, Name = "비비빅", Age = 30, IsActive = false },
                new Person() { Id = 3, Name = "박대철", Age = 24, IsActive = true }
            };

            myDataGrid2.ItemsSource = people;
        }

        private void LoadData3()
        {
            personInfo = new List<Person>
            {
                new Person() { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person() { Id = 2, Name = "비비빅", Age = 30, IsActive = false },
                new Person() { Id = 3, Name = "박대철", Age = 24, IsActive = true },
                new Person() { Id = 4, Name = "탐 크루즈", Age = 45, IsActive = false },
                new Person() { Id = 5, Name = "아리아나 그란데", Age = 32, IsActive = false },
                new Person() { Id = 6, Name = "손흥민", Age = 31, IsActive = true }
            };
        }

        private void singleSelectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (singleSelectDataGrid.SelectedItem is Person selectedPerson)
            {
                Console.WriteLine($"단일 선택: ID={selectedPerson.Id} 이름={selectedPerson.Name}");
            }
            else
            {
                Console.WriteLine("선택된 항목 없음");
            }

            /*
             * is 연산자
             * - 객체가 특정 Type인지 검사할 떄 사용 (= 타입 확인)
             * - 결과를 boolean 타입으로 반환
             * - 형 변환 X
             * 
             * C# 7.0 이후 패턴 매칭 활용 (is + 변수 선언)
             * - is로 타입 확인 + 형 변환 가능
             * - as 보다 간결하며 null 체크 생략 가능
             * 
             * as 연산자
             * - 객체를 지정한 Type으로 변환 시도
             * - 실패 시 null 반환 (예외 발생 X)
             * - 참조 형식 또는 nullable 타입에만 사용 가능
             * - 형 변환과 null 체크 필요
             * - C# 7.0 이후 is 패턴 매칭이 더 간결함
             */

            /*
             * singleSelectDataGrid.SelectedItem => object 타입
             * - DataGrid는 어떤 타입의 데이터가 바인딩될지 모르기 떄문에 가장 일반적인 object 타입으로 반환
             * 
             * is Person selectedPerson
             * - 위 타입이 Person 타입인지 확인 함.
             * - Person 타입이거나 Person 타입으로 변환이 가능한 경우 (true라면) 해당 객체를 Person 타입으로 캐스팅 하여 selectedPerson 이라는 새 변수에 할당 함
             * - 할당된 변수는 if 블록 내에서만 유효하며 Person 타입으로 안전하게 사용할 수 있다
             */
        }

        private void ShowSingleItem_Click(object sender, RoutedEventArgs e)
        {
            if (singleSelectDataGrid.SelectedItem is Person selectedPerson)
            {
                MessageBox.Show($"단일 선택된 사람: \nID : {selectedPerson.Id}\n" +
                                $"이름 : {selectedPerson.Name}\n" +
                                $"나이 : {selectedPerson.Age}\n" +
                                $"활성 : {selectedPerson.IsActive}",
                                "단일 개체 선택",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }

        private void ShowMultiItem_Click(object sender, RoutedEventArgs e)
        {
            if (multiSelectedDataGrid.SelectedItems.Count > 0)
            {
                string selectedInfo = "선택된 사람들: \n";
                foreach (Person p in multiSelectedDataGrid.SelectedItems.Cast<Person>())
                {
                    selectedInfo += $"- {p.Name} ( ID: {p.Id} )\n";
                }
                MessageBox.Show(selectedInfo, "다중 개체 선택", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void multiSelectedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // selectedItems 속성을 통해 현재 선택된 모든 항목에 접근
            if (multiSelectedDataGrid.SelectedItems.Count > 0)
            {
                // 선택된 모든 사람의 이름을 출력
                string selectedNames = string.Join(", ", multiSelectedDataGrid.SelectedItems.Cast<Person>().Select(p => p.Name));
                Console.WriteLine($"다중 선택({multiSelectedDataGrid.SelectedItems.Count}명) : {selectedNames}");

                /*
                 * multiSelectedDataGrid.SelectedItems
                 * - 다중 선택된 항목 가져옴
                 * - 반환 타입 : Object형 List (하나가 아닌 여러개)
                 * 
                 * Cast<Person>()
                 * - Person Type으로 형변환 해야 클래스의 속성에 접근 가능
                 * - 리스트 안의 모든 항목을 Person으로 하나씩 캐스팅
                 * - 아래 코드와 유사함
                 *  List<Person> people = new List<Person>();
                 *  foreach (var item in multiSelectedDataGrid.SelectedItems)
                 *  {
                 *      people.Add((Person)item);
                 *  }
                 *
                 * Cast<>
                 * - LINQ의 Cast<T>() 메서드이며, as와 달리 실패 시 예외가 발생함. 모든 항목이 Person일 때만 사용 가능
                 * 
                 * Select(p => p.Name)
                 * - 형변환 된 Person 객체들 중에서 Name 속성만 꺼내옴
                 * - LINQ의 대표적인 추출 메서드
                 * - p => p.Name (람다식)
                 *  ㄴ 각 항목 p에서 Name 속성을 꺼내라 (p = 임시변수)
                 */
            }
            else {
                Console.WriteLine("선택된 항목 없음");
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}