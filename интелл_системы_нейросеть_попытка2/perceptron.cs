using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace интелл_системы_нейросеть_попытка2 {
    class perceptron {
        List<double> inList = new List<double>();
        List<double> outList = new List<double>();
        List<double> hiddenList = new List<double>();
        List<double> w1List = new List<double>();
        List<double> w2List = new List<double>();
        double h = 1000;

        List<double> error = new List<double>();

        Random rnd = new Random();

        public perceptron(int inCount, int hiddenCount, int outCount) {
            for (int i = 0; i < inCount; i++) {
                inList.Add(0);
            }
            for (int i = 0; i < inCount * hiddenCount; i++) {
                w1List.Add(1);
            }
            for (int i = 0; i < hiddenCount * outCount; i++) {
                w2List.Add(rnd.NextDouble() / 10);
            }
            for (int i = 0; i < hiddenCount; i++) {
                hiddenList.Add(0);
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
            for (int i = 0; i < hiddenList.Count; i++) {
                //hiddenList[i] = Math.Tanh(-sumHidden(i) / h);
                hiddenList[i] = 1 / (1 + Math.Exp(-sumHidden(i) / h));
            }
            for (int i = 0; i < outList.Count; i++) {
                outList[i] = Math.Tanh(-sumOut(i) / h);
                //outList[i] = 1 / (1 + Math.Exp(-sumOut(i) / h));
            }
            return outList;
        }

        public void train(List<double> standart) {
            for (int i = 0; i < hiddenList.Count; i++) {
                //hiddenList[i] = Math.Tanh(-sumHidden(i) / h);
                hiddenList[i] = 1 / (1 + Math.Exp(-sumHidden(i) / h));
            }
            for (int i = 0; i < outList.Count; i++) {
                outList[i] = Math.Tanh(-sumOut(i) / h);
                //outList[i] = 1 / (1 + Math.Exp(-sumOut(i) / h));
            }

            for (int i = 0; i < error.Count; i++) {
                error[i] = outList[i] - standart[i];
            }
            for (int j = 0; j < error.Count; j++) {
                for (int i = 0; i < hiddenList.Count; i++) {
                    w2List[j * hiddenList.Count + i] += error[j] * hiddenList[i];
                }
            }
        }

        public double sumHidden(int n) {
            double s = 0;
            for (int i = 0; i < inList.Count; i++) {
                s += w1List[n * hiddenList.Count + i] * inList[i];
            }
            return s;
        }

        public double sumOut(int n) {
            double s = 0;
            for (int i = 0; i < hiddenList.Count; i++) {
                s += w2List[n * outList.Count + i] * hiddenList[i];
            }
            return s;
        }
    }
}
