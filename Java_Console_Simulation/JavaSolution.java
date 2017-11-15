import java.util.Random;

public class JavaSolution{

  // global variables
  private int reorderPoint = 25;
  private int orderSize = 35;
  private Random random;

  // Constructer that accepts Random generator as parameter
  public JavaSolution(Random random){
    this.random = random;
  }// end of constructer

  public static void main(String []args){
    Random random = new Random();
    JavaSolution main = new JavaSolution(random);
    int profit = 8 - 4;
    double avg = 0.0;

    // for loop to simulate the month 1000 times
    // and display the average loss
    for(int s = 0; s < 1000; s++){
      avg += main.simulateMonth() * (profit);
    }// end of for

    avg /= 1000;
    System.out.println("Average profit lost for January 2018:");
    System.out.println(avg);
    System.out.println("Simulation was run 1000 times.");
  }// end fo main.

  public int simulateMonth(){
    int receiveDay = -1;
    int stock = 0;
    int lostClients = 0;
    boolean activeOrder = false;

    // for loop to run through the business days of the month.
    for(int i = 1; i <= 28; i++){
      int demand = this.getRandomDemand();
      stock -= demand; // Subtract the sales (demand) from the stock.

      // stock received on this day.
      if(i == receiveDay){
        stock += orderSize;
        activeOrder = false;
        receiveDay = -1;
      }// end if

      // lost sales/clients due to stock outage.
      if(stock < 0){
        lostClients += Math.abs(stock);
        stock = 0;
      }// end if

      // reorder stock at reorder Point of 25
      if(stock <= 25 && !activeOrder){
        // Calculate the day that the stock will arrive.
        receiveDay = this.getRandomLeadTime() + i;
        activeOrder = true;
      }// end if
    }// end of for

    return lostClients;
  }// end of simulateMonth

  // Generate an accurate demand (sales) for given day.
  public int getRandomDemand(){
    double r = random.nextDouble();

    // Use data from DayleDemand sheet in excel document.
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

  // Generate an accurate lead time for given order.
  public int getRandomLeadTime(){
    double r = random.nextDouble();

    // Use data from LeadTimeData sheet in excel document.
    if(r < 0.285714286){
      return 2;
    }else if(r < 0.642857143){
      return 3;
    }else{
      return 4;
    }// end if else
  }// end of getRandomLeadTime

}// end of class
