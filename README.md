log4net.Kafka.Common
==========

## Quick Start

### Step 1: Install log4net.Kafka.Core package

```
Install-Package log4net.Kafka.Common
```

### Step 2: Configure log4net sections

```xml
<?xml version="1.0" encoding="utf-8" ?>
<log4net>
  <appender name="KafkaAppender" type="log4net.Kafka.Common.KafkaAppender, log4net.Kafka.Common">
    <KafkaSettings>
      <broker value="10.10.12.180:9092" />
      <topic value="log-crm" />
    </KafkaSettings>
    <layout type="log4net.Kafka.Common.KafkaLogLayout,log4net.Kafka.Common" >
      <appid value="crm" />
    </layout>
  </appender>
  <root>
    <level value="ALL"/>
    <appender-ref ref="KafkaAppender" />
  </root>
</log4net>
```
