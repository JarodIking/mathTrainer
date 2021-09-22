using System;
using System.Collections.Generic;
using System.Text;

namespace mathTrainer
{
    class sumGeneration
    {
        //constructor---------------------------------------------------------------------------
        public sumGeneration(int lvl, int cor, int wro, int lng)
        {
            _level = lvl;
            _correct = cor;
            _wrong = wro;
            _length = lng;

            nums1 = new int[lng];
            operators = new int[lng];
            nums2 = new int[lng];
            answers = new int[lng];

            nums3 = new int[lng];
            operators1 = new int[lng];
            nums4 = new int[lng];
            answers1 = new int[lng];

            nums5 = new int[lng];
            operators2 = new int[lng];
            nums6 = new int[lng];
            answers2 = new int[lng];
        }


        //variables & arrays--------------------------------------------------------------------
        private int _level;
        private int _correct;
        private int _wrong;
        private int _length;

        private string _name;

        //adding and subtraction
        public int[] nums1;
        public int[] operators;
        public int[] nums2;
        public int[] answers;

        //multiplication
        public int[] nums3;
        public int[] operators1;
        public int[] nums4;
        public int[] answers1;

        //All Operators
        public int[] nums5;
        public int[] operators2;
        public int[] nums6;
        public int[] answers2;

        Random random = new Random();
        //properties----------------------------------------------------------------------------
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int Correct
        {
            get { return _correct; }
            set { _correct = value; }
        }

        public int Wrong
        {
            get { return _wrong; }
            set { _wrong = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int gameLength
        {
            get { return _length; }
            set { _length = value; }
        }
        //methods-------------------------------------------------------------------------------
        public void Start()
        {
            createLevel(Level);
        }
        private void createLevel(int lvl)
        {
            int a;
            switch (lvl)
            {
                //Generate subraction and adding equations
                case 1:
                    for (int i = 0; i < gameLength; i++)
                    {
                       nums1[i] = generateAddSubtract(lvl);
                       operators[i] = generateAddSubtract(lvl, 1);
                       nums2[i] = generateAddSubtract(lvl);
                    }

                    for (int i = 0; i < gameLength; i++)
                    {
                        if (operators[i] == 0)
                        {
                            answers[i] = nums1[i] - nums2[i];
                        } else
                        {
                            answers[i] = nums1[i] + nums2[i];
                        }
                    }
                    break;

                //generate multiplication and division equations
                case 2:
                    for (int i = 0; i < gameLength; i++)
                    {
                        a = random.Next(2);
                        generateMultiDiv(lvl, a, i);
                    }
                    break;

                //generate all basic arithemtic equations
                case 3:
                    for (int i = 0; i < gameLength; i++)
                    {
                        a = random.Next(4);
                        generateAll(lvl, a, i);
                    }
                    break;

                default:

                    break;
                    
            }
        }

        private int generateAddSubtract(int lvl, int op = 0)
        {
            //first level equations
            if (lvl == 1 && op == 0)
                return random.Next(100);
            if (lvl == 1 && op == 1)
                return random.Next(2);

            return 0;
        }

        private void generateMultiDiv(int lvl, int op, int i)
        {
            if(op == 0)
            {
                nums3[i] = random.Next(11);
                operators1[i] = 0;
                int num = random.Next(11);
                nums4[i] = num;

                int ans = nums3[i] * nums4[i];

                nums4[i] = ans;

                answers1[i] = num;

            } else
            {
                nums3[i] = random.Next(11);
                operators1[i] = 1;
                nums4[i] = random.Next(11);

                answers1[i] = nums3[i] * nums4[i];
            }
        }

        private void generateAll(int lvl, int op, int i)
        {
            switch (op)
            {
                case 0:
                    nums5[i] = random.Next(101);
                    operators2[i] = 0;
                    nums6[i] = random.Next(101);
                    answers2[i] = nums5[i] + nums6[i];
                    break;

                case 1:
                    nums5[i] = random.Next(101);
                    operators2[i] = 1;
                    nums6[i] = random.Next(101);
                    answers2[i] = nums5[i] - nums6[i];
                    break;

                case 2:
                    nums5[i] = random.Next(11);
                    operators2[i] = 2;
                    nums6[i] = random.Next(11);
                    answers2[i] = nums5[i] * nums6[i];
                    break;

                case 3:
                    nums5[i] = random.Next(11);
                    operators2[i] = 3;
                    int num = random.Next(11);
                    nums6[i] = num;

                    int ans = nums5[i] * nums6[i];

                    nums6[i] = ans;

                    answers2[i] = num;
                    break;
            }
        }

    }
}
