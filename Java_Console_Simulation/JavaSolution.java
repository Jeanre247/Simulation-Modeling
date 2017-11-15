import java.util.Random;

public class JavaSolution{
  private int reorderPoint = 25;
  private int orderSize = 35;
  public Random random;

  public JavaSolution(Random random){
    this.random = random;
  }// end of constructer

  public static void main(String []args){
    Random random = new Random();
    PrepMain main = new PrepMain(random);
    int profit = 8 - 4;
    double avg = 0.0;

    for(int s = 0; s < 1000; s++){
      avg += main.simulateMonth() * (profit);
    }// end of for

    avg /= 1000;
    System.out.println(avg);
  }// end fo main.

  public int simulateMonth(){
    int receiveDay = -1;
    int stock = 0;
    int lostClients = 0;
    boolean activeOrder = false;

    for(int i = 1; i <= 28; i++){
      // subtract sales...
      int demand = this.getRandomDemand();
      stock -= demand;

      // stock received
      if(i == receiveDay){
        stock += orderSize;
        activeOrder = false;
        receiveDay = -1;
      }// end if

      // lost sales or clients
      if(stock < 0){
        lostClients += Math.abs(stock);
        stock = 0;
      }// end if

      // reorder stock at reorderPoint of 25
      if(stock <= 25 && !activeOrder){
        receiveDay = this.getRandomLeadTime() + i;
        activeOrder = true;
      }// end if

    }// end of for

    return lostClients;
  }// end of simulateMonth

  public int getRandomDemand(){
    double r = random.nextDouble();

    if(r < 0.261306533){
      return 5;
    }else if(r < 0.48241206){
      return 6;
    }else if(r < 0.804020101){
      return 7;
    }else{
      return 8;
    }// end if else
  }// end of getRandomDemand

  public int getRandomLeadTime(){
    double r = random.nextDouble();

    if(r < 0.285714286){
      return 2;
    }else if(r < 0.642857143){
      return 3;
    }else{
      return 4;
    }// end if else
  }// end of getRandomLeadTime

}// end of class
