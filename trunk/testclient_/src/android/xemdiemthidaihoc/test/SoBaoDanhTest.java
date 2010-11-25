package android.xemdiemthidaihoc.test;

import android.test.ActivityInstrumentationTestCase2;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.xemdiemthidaihoc.SoBaoDanh;
public class SoBaoDanhTest extends ActivityInstrumentationTestCase2<SoBaoDanh> {
	private SoBaoDanh mActivity;
	private EditText edittext;
	private TextView textview;
	private ImageButton imageButton;
	
	
	public SoBaoDanhTest(){
		super("android.xemdiemthidaihoc", SoBaoDanh.class);
	}
	
	 @Override
    protected void setUp() throws Exception {
        super.setUp();
        mActivity = this.getActivity();
        edittext = (EditText) mActivity.findViewById(android.xemdiemthidaihoc.R.id.EditText01);
        textview=(TextView) mActivity.findViewById(android.xemdiemthidaihoc.R.id.TextView01);
    }
	 public void testPreconditions() {
	      assertNotNull(edittext);
	      assertNotNull(textview);
	 }	 
}

