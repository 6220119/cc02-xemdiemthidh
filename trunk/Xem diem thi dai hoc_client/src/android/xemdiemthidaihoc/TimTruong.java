package android.xemdiemthidaihoc;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;

public class TimTruong extends Activity implements OnClickListener{
	private EditText edit;
	public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.timtruonglayout);
        ImageButton imButton = (ImageButton) findViewById(R.id.ImageButton01);
        imButton.setImageResource(R.drawable.seach);
        imButton.setOnClickListener(this);
        Button dstButton = (Button) findViewById(R.id.Button01);
        dstButton.setOnClickListener(this);
        edit = (EditText) findViewById(R.id.EditText01);
    }
	
	public void onClick(View v) {
		int id = v.getId();
		if(id == R.id.Button01){
	    	Intent intent = new Intent();
	    	intent.setAction("list_truong");    	    
	    	startActivity(intent);
    	}else{
	    	Intent intent = new Intent();
	    	intent.putExtra("ma_truong", edit.getText().toString());
	    	intent.setAction("list_thi_sinh");    	    
	    	startActivity(intent);
    	}
	}
}
