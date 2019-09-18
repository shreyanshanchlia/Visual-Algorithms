// An iterative implementation of quick sort without any function 
#include <bits/stdc++.h> 
using namespace std; 
int main() 
{ 
    int n;
    cout<<"enter no. of elements of array: ";
    cin>>n;
    int arr[n];
	cout<<"\nenter every element seprated by an enter : \n"; 
    for(int i=0;i<n;i++)
    {
    	cin>>arr[i];
	}
	cout<<"\nwe are sorting your array wait till process ends. thank you!\n";
	int l=0;
	int h=n-1;
     // Create an auxiliary stack 
    int stack[h - l + 1]; 
    // initialize top of stack 
    int top = -1; 
    // push initial values of l and h to stack 
    stack[++top] = l; 
    stack[++top] = h; 
    // Keep popping from stack while is not empty 
    while (top >= 0) 
	{ 
        // Pop h and l 
        h = stack[top--]; 
        l = stack[top--]; 
  
        // Set pivot element at its correct position 
        // in sorted array 
        int x = arr[h]; 
    	int i = (l - 1); 
  
   		 for (int j = l; j <= h - 1; j++)
		 { 
        	if (arr[j] <= x) 
			{ 
            	i++; 
            	int temp = arr[i];
            	arr[i]=arr[j];
            	arr[j]=temp;
        	} 
   		 } 
    	int temp = arr[i+1];
            	arr[i+1]=arr[h];
            	arr[h]=temp; 
        int p = i+1; 
  
        // If there are elements on left side of pivot, 
        // then push left side to stack 
        if (p - 1 > l)
		{ 
            stack[++top] = l; 
            stack[++top] = p - 1; 
        } 
  
        // If there are elements on right side of pivot, 
        // then push right side to stack 
        if (p + 1 < h) 
		{ 
            stack[++top] = p + 1; 
            stack[++top] = h; 
        } 
    }
    cout<<"new sorted array is as follows:\n";
	for(int i=0; i<n; i++)
	{
		cout<<arr[i]<<" ";
	 } 
    return 0; 
} 
  
// This is code is contributed by kishor sarswat
