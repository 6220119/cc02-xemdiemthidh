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

import sobaodanh.ChiTietThiSinh;
import android.xemdiemthidaihoc.R;
import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

public class ListTruong extends ListActivity {
	
	private static final String SOAP_ACTION = "http://tempuri.org/IXDTService/GetAllTruong";
    private static final String METHOD_NAME = "GetAllTruong";
    private static final String NAMESPACE = "http://tempuri.org/";
    private static final String URL = "http://10.0.2.2:3744/XemDiemThiService.svc";
    
    private final Handler handler = new Handler();
    private ProgressDialog pd;
    private static final String TEN_TRUONG = "ten_truong";
    private static final String INTENT = "intent";
    private static final String ACTION = "list_thi_sinh";
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
	        	List<Map<String, Object>> data = new ArrayList<Map<String, Object>>();	        	
		        SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);        
		        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
		        envelope.dotNet = true;             
		        envelope.setOutputSoapObject(request);
		        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
		        
		        try{
		            androidHttpTransport.call(SOAP_ACTION, envelope);
		            SoapObject result=(SoapObject)envelope.getResponse();
		            int sotruong = result.getPropertyCount();
		            for(int i = 0; i < sotruong; i++){
		            	SoapObject truong = (SoapObject) result.getProperty(i);
		            	String name =  truong.getProperty("TenTruong").toString();
		            	String mt =  truong.getProperty("MaTruong").toString();
		            	ListTruong.this.addItem(data, name, mt);		            	
		            }
		            
		            ListTruong.this.setListAdapter(new SimpleAdapter(ListTruong.this,data, android.R.layout.simple_list_item_1,
		            		new String[]{TEN_TRUONG},new int[]{android.R.id.text1}));
		            ListView lv = getListView();
		      	  	lv.setTextFilterEnabled(true);
			      	lv.setOnItemClickListener(new OnItemClickListener() {
			      	public void onItemClick(AdapterView<?> parent, View view,
			             int position, long id) {
			      	      // When clicked, show a toast with the TextView text
				      		Toast.makeText(getApplicationContext(), ((TextView) view).getText(),
				      	    		  Toast.LENGTH_SHORT).show();
				      		Map<String, Object> temp = (Map<String, Object>) parent.getItemAtPosition(position);
				      		Intent intent = (Intent) temp.get(INTENT);
				      		startActivity(intent);
			      	    }
			      	 });
			      	 pd.dismiss();
			     }catch(XmlPullParserException e){
			    	 Toast.makeText(getApplicationContext(), e.getMessage(),
		      	    		  Toast.LENGTH_SHORT).show();
			    	 pd.setMessage(e.getMessage());             
				 }catch(IOException e){
			    	 Toast.makeText(getApplicationContext(), e.getMessage(),
		      	    		  Toast.LENGTH_SHORT).show();
			    	 pd.setMessage(e.getMessage());             
				 }
	          }
        });
    }
    private void addItem(List<Map<String, Object>> data, String name , String MT){
    	Map<String, Object> map = new HashMap<String, Object>();
    	Intent intent = new Intent();
    	intent.putExtra("ma_truong", MT);
    	intent.setAction(ACTION);
    	map.put(TEN_TRUONG, name);
    	map.put(INTENT, intent);
    	data.add(map);
    }
}
