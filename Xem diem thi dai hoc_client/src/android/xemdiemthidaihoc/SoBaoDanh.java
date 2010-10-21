package android.xemdiemthidaihoc;



import sobaodanh.ChiTietThiSinh;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.EditText;
import android.widget.ImageButton;


public class SoBaoDanh extends Activity implements OnClickListener {
    /** Called when the activity is first created. */
	private static final int chi_tiet = 1;
	private EditText sbd;
	private ProgressDialog pd;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.setContentView(R.layout.sobaodanh);
        sbd = (EditText) this.findViewById(R.id.EditText01);
        ImageButton button = (ImageButton)this.findViewById(R.id.ImageButton01);
        button.setImageResource(R.drawable.seach);        
        button.setOnClickListener(this); 
    }
    
	@Override
	public void onClick(View v) {		
    	Intent intent = new Intent();
    	intent.setAction("chi_tiet");
    	intent.putExtra("sbd", sbd.getText().toString());
    	startActivityForResult(intent, chi_tiet);
	}
}
