package dstruong;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.xmlpull.v1.XmlPullParserException;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

public class ListThiSinh extends ListActivity {
	private static final String SOAP_ACTION = "http://tempuri.org/IXDTService/GetTop100ThiSinhDetailsByMaTruong";
    private static final String METHOD_NAME = "GetTop100ThiSinhDetailsByMaTruong";
    private static final String NAMESPACE = "http://tempuri.org/";
    private static final String URL = "http://10.0.2.2:3744/XemDiemThiService.svc";
    
    private final Handler handler = new Handler();
    private ProgressDialog pd;
    private static final String HO_TEN = "ho_ten";
    private static final String INTENT = "intent";
    private static final String ACTION = "chi_tiet";
    
    @Override
	public void onCreate(Bundle savedInstanceState) {
	  super.onCreate(savedInstanceState);
	  pd = ProgressDialog.show(this, "Đang nhận dữ liệu....",    			
			"Lấy dữ liệu", true, false);
	 // setListAdapter(new ArrayAdapter<String>(this,R.layout.list_item,new String[] {}));
	  doProcess();
	}
    public void doProcess()
    {
        handler.post(new Runnable() {
	        public void run(){
	        ///////////////////////////////////////////////////////////////////
	        	String mt = getIntent().getStringExtra("ma_truong");
	        	List<Map<String, Object>> data = new ArrayList<Map<String, Object>>();	        	
		        SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);        
		        request.addProperty("maTruong",mt);
		        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
		        envelope.dotNet = true;             
		        envelope.setOutputSoapObject(request);
		        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
		        
		        try{
		            androidHttpTransport.call(SOAP_ACTION, envelope);
		            SoapObject result=(SoapObject)envelope.getResponse();
		            if(result == null){
				    	 Toast toast = Toast.makeText(getApplicationContext(), "Mả trường không đúng",
			      	    		  Toast.LENGTH_SHORT);
				    	 toast.setDuration(1000);
				    	 toast.show();
		            }
		            int sothisinh = result.getPropertyCount();
		            for(int i = 0; i < sothisinh; i++){
		            	SoapObject thisinh = (SoapObject) result.getProperty(i);
		            	int diem =  Integer.parseInt(thisinh.getProperty("Diem1").toString());
		            	diem +=  Integer.parseInt(thisinh.getProperty("Diem2").toString());
		            	diem +=  Integer.parseInt(thisinh.getProperty("Diem3").toString());
		            	
		            	String name =  thisinh.getProperty("HoTen").toString();
		            	String sbd =  thisinh.getProperty("SoBaoDanh").toString();
		            	ListThiSinh.this.addItem(data, name, sbd, diem);		            	
		            }
		            
		            ListThiSinh.this.setListAdapter(new SimpleAdapter(ListThiSinh.this,data, android.R.layout.simple_list_item_1,
		            		new String[]{HO_TEN},new int[]{android.R.id.text1}));
		            ListView lv = getListView();
		      	  	lv.setTextFilterEnabled(true);
			      	lv.setOnItemClickListener(new OnItemClickListener() {
			      	public void onItemClick(AdapterView<?> parent, View view,
			             int position, long id) {
			      	      // When clicked, show a toast with the TextView text			      	     
			      		 Toast.makeText(getApplicationContext(), ((TextView) view).getText(),
			      	    		  Toast.LENGTH_SHORT).show();
			      	      Map temp = (Map)parent.getItemAtPosition(position);
			      	      Intent intent = (Intent) temp.get("intent");
			      	      startActivity(intent);
			      	    }
			      	 });
			      	 pd.dismiss();
			     }catch(XmlPullParserException e){
			    	 pd.setMessage(e.getMessage());             
				 }catch(Exception e){
			    	 pd.setMessage(e.getMessage());             
				 }
	          }
        });
    }
    private void addItem(List<Map<String, Object>> data, String name , String sbd, int diem){
    	Map<String, Object> map = new HashMap<String, Object>();
    	Intent intent = new Intent();
    	intent.putExtra("sbd", sbd);
    	intent.setAction(ACTION);
    	map.put(HO_TEN, name + " : " + diem + " điểm");
    	map.put(INTENT, intent);
    	data.add(map);
    }
}
