using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamTree : IExam
    {
        private readonly ExamNode _head;
        private ExamNode _currNode;
        private MoveDirection _currMoveDirection = MoveDirection.Stay;
        private ExamPage _currPage;

        public ExamTree(ExamNode rootNode)
        {
            _head = rootNode;
            _currNode = _head;
        }

        public void Start()
        {
            _currNode = _head;
            _currPage = null;
            _currMoveDirection = MoveDirection.Stay;
        }
        public ExamPage Next()
        {
            if (_currPage != null)
            {
                switch (_currPage.Buttons.Count)
                {
                    case 0:
                        break;
                    case 1:
                        _currPage.Buttons[0].OnClickEvent -= OnLeft;
                        break;
                    default:
                        _currPage.Buttons[0].OnClickEvent -= OnLeft;
                        _currPage.Buttons[1].OnClickEvent -= OnRight;
                        break;
                }
            }

            switch (_currMoveDirection)
            {
                case MoveDirection.Left:
                    _currNode = _currNode.Left;
                    break;
                case MoveDirection.Right:
                    _currNode = _currNode.Right;
                    break;
            }
            if (_currNode?.Page == null)
            {
                return null;
            }

            _currPage = _currNode.Page;
            switch (_currPage.Buttons.Count)
            {
                case 0:
                    break;
                case 1:
                    _currPage.Buttons[0].OnClickEvent += OnLeft;
                    break;
                default:
                    _currPage.Buttons[0].OnClickEvent += OnLeft;
                    _currPage.Buttons[1].OnClickEvent += OnRight;
                    break;
            }

            return _currPage;
        }

        private void OnLeft()
        {
            _currMoveDirection = MoveDirection.Left;
        }
        private void OnRight()
        {
            _currMoveDirection = MoveDirection.Right;
        }
    }
}
