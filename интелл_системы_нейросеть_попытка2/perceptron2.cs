using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace интелл_системы_нейросеть_попытка2 {
    class perceptron2 {
        List<double> inList = new List<double>();
        List<double> outList = new List<double>();
        List<double> w1List = new List<double>();
        double h = 2.0;

        List<double> error = new List<double>();

        Random rnd = new Random();

        public perceptron2(int inCount, int outCount) {
            for (int i = 0; i < inCount; i++) {
                inList.Add(0);
            }
            for (int i = 0; i < inCount * outCount; i++) {
                w1List.Add(rnd.NextDouble() / 10);
            }
            for (int i = 0; i < outCount; i++) {
                outList.Add(0);
                error.Add(0);
            }
        }

        public void inData(List<double> listData) {
            for (int i = 0; i < inList.Count; i++) {
                inList[i] = listData[i];
            }
        }

        public List<double> work() {
            for (int i = 0; i < outList.Count; i++) {
                if (sumOut(i) > h) {
                    outList[i] = 1;
                }
                else {
                    outList[i] = 0;
                }
            }
            return outList;
        }

        public void train(List<double> standart) {
            for (int i = 0; i < outList.Count; i++) {
                if (sumOut(i) > h) {
                    outList[i] = 1;
                }
                else {
                    outList[i] = 0;
                }
            }

            for (int i = 0; i < error.Count; i++) {
                error[i] = outList[i] - standart[i];
            }
            for (int j = 0; j < error.Count; j++) {
                for (int i = 0; i < inList.Count; i++) {
                    w1List[j * inList.Count + i] += error[j] * inList[i];
                }
            }
        }

        public double sumOut(int n) {
            double s = 0;
            for (int i = 0; i < inList.Count; i++) {
                s += w1List[n * outList.Count + i] * inList[i];
            }
            return s;
        }
    }
}
