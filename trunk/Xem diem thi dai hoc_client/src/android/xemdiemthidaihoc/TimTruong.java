package android.xemdiemthidaihoc;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ImageButton;
import android.widget.TextView;

public class TimTruong extends Activity {
	public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.timtruonglayout);
        ImageButton button = (ImageButton) findViewById(R.id.ImageButton01);
        button.setImageResource(R.drawable.seach);
    }
}
