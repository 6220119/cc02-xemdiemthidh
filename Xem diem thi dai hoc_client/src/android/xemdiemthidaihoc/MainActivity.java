package android.xemdiemthidaihoc;
//
import android.app.TabActivity;
import android.content.Intent;
import android.content.res.Resources;
import android.os.Bundle;
import android.widget.TabHost;

public class MainActivity extends TabActivity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        Resources res = getResources(); // Resource object to get Drawables
        TabHost tabHost = getTabHost();  // The activity TabHost
        TabHost.TabSpec spec;  // Resusable TabSpec for each tab
        Intent intent;  // Reusable Intent for each tab

        // Create an Intent to launch an Activity for the tab (to be reused)
        intent = new Intent().setClass(this, SoBaoDanh.class);

        // Initialize a TabSpec for each tab and add it to the TabHost
        spec = tabHost.newTabSpec("sobaodanh").setIndicator("Xem diem",
                          res.getDrawable(R.drawable.sobaodanh))
                      .setContent(intent);
        tabHost.addTab(spec);

        // Do the same for the other tabs
        intent = new Intent().setClass(this, TimTruong.class);
        spec = tabHost.newTabSpec("theotruong").setIndicator("Top",
                          res.getDrawable(R.drawable.theotruong))
                      .setContent(intent);
        tabHost.addTab(spec);

        intent = new Intent().setClass(this, About.class);
        spec = tabHost.newTabSpec("about").setIndicator("About",
                          res.getDrawable(R.drawable.about))
                      .setContent(intent);
        tabHost.addTab(spec);

        tabHost.setCurrentTab(0);
    }
}